Imports System.Data
Imports Newtonsoft.Json


Partial Class l294
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
            Exit Sub
        End If


        '  dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 AND id_bd=389 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
        Dim dt2 As DataTable
        dt2 = cm.GetOutputTab
        cm.GetCommonParams(dt2)
		
		
		'''''''''''''''''''''''''''''''''''''''''
		
		
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 AND id_bd=400 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")

        If dt.Rows.Count > 0 Then
		 
            AddValue(dt2, dt, "Уровень в резервуаре 9.4.1", "M5", "216")
            AddValue(dt2, dt, "Уровень в резервуаре 9.4.2", "M6", "217")
            AddValue(dt2, dt, "Расход на трубопроводе Ш1", "P1", "218")
       
        End If

		'''''''''''''''''''''''''''''''''''''''
		
		
		Dim dr As DataRow
        Dim v As UShort
        Dim T0 As UShort
		Dim T100 As UShort
	

        '''''''''''''''''''''''''''''''  "ЦМО_ШУ_22"

        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 AND id_bd=408 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
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
			
			 
        End If




        '1M1
        dr = dt2.NewRow
        dr("ID") = "94.41"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T100, 0) Then
            If cm.IsBitSet(T0, 2) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
			end if
            If cm.IsBitSet(T0, 0) Then
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
			If cm.IsBitSet(T0, 1) Then
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Дист."
            End If
			
		else
			If cm.IsBitSet(T0, 2) Then
                dr("INFO") = "Автомат"
			end if
            If cm.IsBitSet(T0, 0) Then
                dr("INFO") = "Руч."
            End If
			If cm.IsBitSet(T0, 1) Then
                dr("INFO") = "Дист."
            End If

        End If

        If cm.IsBitSet(T0, 11) Then
            dr("COLOR") = "RED"
			If cm.IsBitSet(T0, 2) Then
                dr("INFO") = "Авария. Автомат"
			end if
            If cm.IsBitSet(T0, 0) Then
                dr("INFO") = "Авария. Руч."
            End If
			If cm.IsBitSet(T0, 1) Then
                dr("INFO") = "Авария. Дист."
            End If
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)


        '1M2
        dr = dt2.NewRow
        dr("ID") = "94.42"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        
        If cm.IsBitSet(T100, 1) Then
            If cm.IsBitSet(T0, 6) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
			end if
            If cm.IsBitSet(T0, 4) Then
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
			If cm.IsBitSet(T0, 5) Then
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Дист."
            End If
			
		else
			If cm.IsBitSet(T0, 6) Then
                dr("INFO") = "Автомат"
			end if
            If cm.IsBitSet(T0, 4) Then
                dr("INFO") = "Руч."
            End If
			If cm.IsBitSet(T0,5) Then
                dr("INFO") = "Дист."
            End If

        End If

        If cm.IsBitSet(T0, 11) Then
            dr("COLOR") = "RED"
			If cm.IsBitSet(T0, 6) Then
                dr("INFO") = "Авария. Автомат"
			end if
            If cm.IsBitSet(T0, 4) Then
                dr("INFO") = "Авария. Руч."
            End If
			If cm.IsBitSet(T0,5) Then
                dr("INFO") = "Авария. Дист."
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
