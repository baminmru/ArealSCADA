Imports System.Data
Imports Newtonsoft.Json


Partial Class l24
    Inherits System.Web.UI.Page

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
        Dim dt2 As DataTable

        Dim dr As DataRow
        Dim v As UShort
        Dim T0 As UShort
        Dim T100 As UShort
		Dim T201 As UShort
        Dim T250 As UShort
        



        dt2 = cm.GetOutputTab
        cm.GetCommonParams(dt2)




        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 AND id_bd=401 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")

		
		'''''''''''''''''''''''''''''
		
        

        If dt.Rows.Count > 0 Then
            AddValue(dt2, dt, "Давление насоса 1М1", "T5", "260")
            AddValue(dt2, dt, "Давление насоса 1М2", "T6", "261")
            AddValue(dt2, dt, "Давление насоса 1М3", "P1", "262")
            AddValue(dt2, dt, "Давление насоса 1М4", "P2", "263")
            AddValue(dt2, dt, "Давление насоса 2М1", "P3", "264")
            AddValue(dt2, dt, "Давление насоса 2М2", "P4", "265")
			AddValue(dt2, dt, "Расход 1", "P5", "266")
			AddValue(dt2, dt, "Расход 2", "P6", "267")
            AddValue(dt2, dt, "Уровень в приямке", "V1", "268")
            
        End If

		''''''''''''''''''''''''''''''''''''''''''''
		


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
                T250 = CType(dt.Rows(0)("T4"), UShort)
            Else
                T250 = 0
            End If
            

        End If


        dr = dt2.NewRow
        dr("ID") = "4.53"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
		dr("INFO") = "-"

        If cm.IsBitSet(T0, 8) Then
			dr("COLOR") = "GREEN"
            dr("INFO") = "Открыта"
        End If
		
		If cm.IsBitSet(T0, 9) Then
			dr("COLOR") = ""
            dr("INFO") = "Закрыта"
        End If
		
		If cm.IsBitSet(T0, 6) Then
			dr("COLOR") = "YELLOW"
            dr("INFO") = "Перегрев"
        End If
		
		If cm.IsBitSet(T0, 7) Then
			dr("COLOR") = "RED"
            dr("INFO") = "Авария"
        End If

        dt2.Rows.Add(dr)


		dr = dt2.NewRow
        dr("ID") = "4.54"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
		dr("INFO") = "-"

        If cm.IsBitSet(T201, 1) Then
			dr("COLOR") = "GREEN"
            dr("INFO") = "Открыта"
        End If
		
		If cm.IsBitSet(T201, 0) Then
			dr("COLOR") = ""
            dr("INFO") = "Закрыта"
        End If
		
		If cm.IsBitSet(T0, 10) Then
			dr("COLOR") = "YELLOW"
            dr("INFO") = "Перегрев"
        End If
		
		If cm.IsBitSet(T0, 11) Then
			dr("COLOR") = "RED"
            dr("INFO") = "Авария"
        End If

        dt2.Rows.Add(dr)


		dr = dt2.NewRow
        dr("ID") = "4.56"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
		dr("INFO") = "-"

        If cm.IsBitSet(T201, 6) Then
			dr("COLOR") = "GREEN"
            dr("INFO") = "Открыта"
        End If
		
		If cm.IsBitSet(T201,7) Then
			dr("COLOR") = ""
            dr("INFO") = "Закрыта"
        End If
		
		If cm.IsBitSet(T201,4 ) Then
			dr("COLOR") = "YELLOW"
            dr("INFO") = "Перегрев"
        End If
		
		If cm.IsBitSet(T201, 5) Then
			dr("COLOR") = "RED"
            dr("INFO") = "Авария"
        End If

        dt2.Rows.Add(dr)
		
		
		
		dr = dt2.NewRow
        dr("ID") = "4.60"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
		dr("INFO") = "-"

        If cm.IsBitSet(T201, 10) Then
			dr("COLOR") = "GREEN"
            dr("INFO") = "Открыта"
        End If
		
		If cm.IsBitSet(T201,11) Then
			dr("COLOR") = ""
            dr("INFO") = "Закрыта"
        End If
		
		If cm.IsBitSet(T201,8 ) Then
			dr("COLOR") = "YELLOW"
            dr("INFO") = "Перегрев"
        End If
		
		If cm.IsBitSet(T201, 9) Then
			dr("COLOR") = "RED"
            dr("INFO") = "Авария"
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
