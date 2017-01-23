Imports System.Data
Imports Newtonsoft.Json


Partial Class l282
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
        dt2 = cm.GetOutputTab
        cm.GetCommonParams(dt2)
		
		
		'''''''''''''''''''''''''''''
		
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 AND id_bd=400 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")

        If dt.Rows.Count > 0 Then
            AddValue(dt2, dt, "Расход на трубопроводе В1.ЭН", "V1", "206")
            AddValue(dt2, dt, "Давление перед фильтром 3.1", "V2", "207")
            AddValue(dt2, dt, "Давление перед фильтром 3.2", "V3", "208")
            AddValue(dt2, dt, "Давление перед фильтром 3.3", "V4", "209")
            AddValue(dt2, dt, "Расход на трубопроводе В1.ЭН", "V5", "210")
            AddValue(dt2, dt, "Давление перед фильтром 3.4", "V6", "211")


 

            AddValue(dt2, dt, "Давление перед фильтром 3.5", "M1", "212")
            AddValue(dt2, dt, "Давление перед фильтром 3.6", "M2", "213")
            AddValue(dt2, dt, "Уровень в резервуаре 4.1", "M3", "214")
            AddValue(dt2, dt, "Давление после насоса 2М1", "M4", "215")
            AddValue(dt2, dt, "Давление после насоса 2М2", "M5", "216")
            AddValue(dt2, dt, "Расход на трубопроводе В1.1", "M6", "217")
            AddValue(dt2, dt, "Уровень в резервуаре 4.2", "P1", "218")
            AddValue(dt2, dt, "Давление после насоса 2М3", "P2", "219")
            AddValue(dt2, dt, "Давление после насоса 2М4", "P3", "220")
            AddValue(dt2, dt, "Расход на трубопроводе В1.1", "P4", "221")
            AddValue(dt2, dt, "Расход на трубопроводе В3.3", "P5", "222")
            AddValue(dt2, dt, "Расход на трубопроводе В3.3", "P6", "223")
            AddValue(dt2, dt, "Уровень в резервуаре 8.1.1", "Q1", "224")
            AddValue(dt2, dt, " Уровень в резервуаре 8.1.2", "Q2", "225")
            AddValue(dt2, dt, "Давление после насоса 1М1", "Q3", "226")
            AddValue(dt2, dt, "Давление после насоса 1М2", "Q4", "227")
            AddValue(dt2, dt, "Давление после насоса 1М3", "Q5", "228")
            AddValue(dt2, dt, "Давление после насоса 1М4", "Q6", "229")
            AddValue(dt2, dt, "Давление после насоса 1М5", "G1", "230")
            AddValue(dt2, dt, "Давление после насоса 1М6", "G2", "231")
            AddValue(dt2, dt, "Давление после воздуходувки ВМ1", "G3", "232")
            AddValue(dt2, dt, "Давление после воздуходувки ВМ2", "G4", "233")
        End If

		''''''''''''''''''''''''''''''''''''''''''''
		
        Dim dr As DataRow
        Dim v As UShort
        Dim T0 As UShort
        Dim T100 As UShort
        

        '''''''''''''''''''''''''''''''  "ЦВО_ШУ_17"

        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 AND id_bd=402 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")


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
		end if
		
		
		 '8M1
        dr = dt2.NewRow
        dr("ID") = "82.1"
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
		end if
		If cm.IsBitSet(T0, 11) Then
			If cm.IsBitSet(T0, 0) Then
                dr("COLOR") = "RED"
                dr("INFO") = "Авария. Автомат"
            Else
                dr("COLOR") = "RED"
                dr("INFO") = "Авария. Руч."
            End If
			dr("BLINK") = "YES"
        End If

       

        dt2.Rows.Add(dr)
		
		
		
		 '8M2
        dr = dt2.NewRow
        dr("ID") = "82.2"
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
		end if
		
		If cm.IsBitSet(T0, 11) Then
			If cm.IsBitSet(T0, 2) Then
                dr("COLOR") = "RED"
                dr("INFO") = "Авария. Автомат"
            Else
                dr("COLOR") = "RED"
                dr("INFO") = "Авария. Руч."
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
