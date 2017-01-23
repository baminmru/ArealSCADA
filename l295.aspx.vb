Imports System.Data
Imports Newtonsoft.Json


Partial Class l295
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
            Exit Sub
        End If


        '  dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 AND id_bd=389 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
        Dim dt2 As DataTable
        dt2 = cm.GetOutputTab
        cm.GetCommonParams(dt2)
		Dim dr As DataRow
        Dim v As UShort
        Dim T0 As UShort
		Dim T100 As UShort
		Dim T201 As UShort
        Dim T211 As UShort

		
		'''''''''''''''''''''''''''''''  "ЦМО_ШУ_21"

        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 AND id_bd=407 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
        If dt.Rows.Count > 0 Then
            If Not (TypeOf (dt.Rows(0)("T1")) Is DBNull) Then
                T0 = CType(dt.Rows(0)("T1"), UShort)
            Else
                T0 = 0
            End If

            If Not (TypeOf (dt.Rows(0)("T2")) Is DBNull) Then
                T100 = CType(dt.Rows(0)("T2"), UShort)
            Else
                T100 = 0
            End If
			
			 If Not (TypeOf (dt.Rows(0)("T3")) Is DBNull) Then
                T201 = CType(dt.Rows(0)("T3"), UShort)
            Else
                T201 = 0
            End If
			
			 If Not (TypeOf (dt.Rows(0)("T4")) Is DBNull) Then
                T211 = CType(dt.Rows(0)("T4"), UShort)
            Else
                T211 = 0
            End If
        End If




        '1M3
        dr = dt2.NewRow
        dr("ID") = "95.41"
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

        If cm.IsBitSet(T100, 5) Then
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
        dr("ID") = "95.42"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T0, 7) Then
            If cm.IsBitSet(T0,6) Then
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

      

        If cm.IsBitSet(T211, 1) Then
            dr("COLOR") = "RED"
			
			If cm.IsBitSet(T0, 6) Then
                dr("INFO") = "Авария. Авт"
            Else
                dr("INFO") = "Авария. Руч"
            End If
			
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)
		
		
		
		  '1M5
        dr = dt2.NewRow
        dr("ID") = "95.43"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T0, 9) Then
            If cm.IsBitSet(T0,8) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If

		else
			If cm.IsBitSet(T0, 8) Then
                dr("INFO") = "Автомат"
            Else
                dr("INFO") = "Руч."
            End If

        End If

      

        If cm.IsBitSet(T211, 3) Then
            dr("COLOR") = "RED"
			
			If cm.IsBitSet(T0, 8) Then
                dr("INFO") = "Авария. Авт"
            Else
                dr("INFO") = "Авария. Руч"
            End If
			
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)
		
		
		
		  '1M6
        dr = dt2.NewRow
        dr("ID") = "95.44"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T201 ,1) Then
            If cm.IsBitSet(T201,0) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If

		else
		 If cm.IsBitSet(T201,0) Then
                dr("INFO") = "Автомат"
            Else
                dr("INFO") = "Руч."
            End If

        End If

      

        If cm.IsBitSet(T211, 5) Then
            dr("COLOR") = "RED"
			
			 If cm.IsBitSet(T201,0) Then
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



    End Sub


End Class
