Imports System.Data
Imports Newtonsoft.Json


Partial Class l291
    Inherits System.Web.UI.Page


    Private Function IsBitSet(ByVal V As UShort, bit As Byte) As Boolean

        If bit >= 0 And bit <= 15 Then
            If (V And (1 << bit)) <> 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
	
	Private Sub AddValue(dt2 As DataTable, dt As DataTable, Name As String, fieldName As String, htmlID As String)
        Dim dr As DataRow
        dr = dt2.NewRow
        dr("ID") = htmlID
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = Name + ": " + dt.Rows(0)(fieldName).ToString
        dt2.Rows.Add(dr)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Exit Sub
        Dim jj As JOut
        Dim cm As CMConnector
        cm = New CMConnector()
        Dim dt As DataTable
        If Not cm.Init() Then

            dt = New DataTable
            jj = New JOut
            jj.success = "false"
            jj.data = dt
            jj.msg = "Error"
            Response.Clear()
            Response.Write(JsonConvert.SerializeObject(jj))
            Response.End() 
 cm.Close()
            Exit Sub
        End If


        Dim dt2 As DataTable
        dt2 = cm.GetOutputTab
        cm.GetCommonParams(dt2)
		
		
		'''''''''''''''''''''''''''''''''''''''''
		
		
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=400 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")

        If dt.Rows.Count > 0 Then
		   AddValue(dt2, dt, "Давление после насоса 9М1", "T3", "202")
		   AddValue(dt2, dt, "Давление после насоса 9М2", "T4", "203")
		   AddValue(dt2, dt, "Давление после насоса 9М3", "T5", "204")
	       AddValue(dt2, dt, "Давление после насоса 9М4", "T6", "205")
		
		
            AddValue(dt2, dt, "Уровень в резервуаре 1.1", "V1", "206")
            AddValue(dt2, dt, "Уровень в резервуаре 1.2", "V2", "207")
            AddValue(dt2, dt, "Расход на трубопроводе К3.2", "V3", "208")
            AddValue(dt2, dt, "Расход на трубопроводе К3.3", "V4", "209")
            AddValue(dt2, dt, "Давление после воздуходувки 7М1", "V5", "210")
            AddValue(dt2, dt, "Давление после воздуходувки 7М2", "V6", "211")

            AddValue(dt2, dt, " Уровень в резервуаре 3.1", "M1", "212")
            AddValue(dt2, dt, " Уровень в резервуаре 3.2", "M2", "213")
            AddValue(dt2, dt, "Давление после насосов 9М1", "M3", "214")
            AddValue(dt2, dt, "Давление после насосов 9М2", "M4", "215")
            AddValue(dt2, dt, "Уровень в резервуаре 9.4.1", "M5", "216")
            AddValue(dt2, dt, "Уровень в резервуаре 9.4.2", "M6", "217")
            AddValue(dt2, dt, "Расход на трубопроводе Ш1", "P1", "218")
       
        End If

		'''''''''''''''''''''''''''''''''''''''

		
		
		Dim dr As DataRow
        Dim v As UShort
        Dim T0 As UShort
        Dim T211 As UShort


        '''''''''''''''''''''''''''''''  "ЦМО_ШУ_19"

        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=405 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
        If dt.Rows.Count > 0 Then
            If Not (TypeOf (dt.Rows(0)("T1")) Is DBNull) Then
                T0 = CType(dt.Rows(0)("T1"), UShort)
            Else
                T0 = 0
            End If

            If Not (TypeOf (dt.Rows(0)("T2")) Is DBNull) Then
                T211 = CType(dt.Rows(0)("T2"), UShort)
            Else
                T211 = 0
            End If
        End If




        '1M1
        dr = dt2.NewRow
        dr("ID") = "91.42"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T0, 1) Then
            If cm.IsBitSet(T0, 0) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
			If cm.IsBitSet(T0, 0) Then
                dr("INFO") = "Автомат"
            Else
                dr("INFO") = "Руч."
            End If

        End If

        If cm.IsBitSet(T211, 1) Then
            dr("COLOR") = "RED"
			If cm.IsBitSet(T0, 0) Then
                dr("INFO") = "Авария. Авт"
            Else
                dr("INFO") = "Авария. Руч"
            End If
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)


        '1M2
        dr = dt2.NewRow
        dr("ID") = "91.43"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T0, 3) Then
            If cm.IsBitSet(T0, 2) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If

		else
			If cm.IsBitSet(T0, 2) Then
                dr("INFO") = "Автомат"
            Else
                dr("INFO") = "Руч."
            End If

        End If

      

        If cm.IsBitSet(T211, 3) Then
            dr("COLOR") = "RED"
			
			If cm.IsBitSet(T0, 2) Then
                dr("INFO") = "Авария. Авт"
            Else
                dr("INFO") = "Авария. Руч"
            End If
			
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)



        '1M3
        dr = dt2.NewRow
        dr("ID") = "91.44"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T0, 5) Then

            If cm.IsBitSet(T0, 4) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
			If cm.IsBitSet(T0, 4) Then
                dr("INFO") = "Автомат"
            Else
                dr("INFO") = "Руч."
            End If

        End If

        If cm.IsBitSet(T211, 5) Then
            dr("COLOR") = "RED"
            If cm.IsBitSet(T0, 4) Then
                dr("INFO") = "Авария. Авт"
            Else
                dr("INFO") = "Авария. Руч"
            End If
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)


        '1M4
        dr = dt2.NewRow
        dr("ID") = "91.45"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

         If cm.IsBitSet(T0, 7) Then

            If cm.IsBitSet(T0, 6) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
			If cm.IsBitSet(T0, 6) Then
                dr("INFO") = "Автомат"
            Else
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T211, 7) Then
            dr("COLOR") = "RED"
            If cm.IsBitSet(T0, 6) Then
                dr("INFO") = "Авария. Авт"
            Else
                dr("INFO") = "Авария. Руч"
            End If
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)


       
		
		
		

        jj = New JOut
        jj.success = "true"
        jj.data = dt2
        jj.msg = "OK"
        Response.Clear()
        Response.Write(JsonConvert.SerializeObject(jj))
        Response.End() 
 cm.Close()



    End Sub


End Class
