﻿Imports System.Data
Imports Newtonsoft.Json


Partial Class l284
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
			cm.Close()
            Exit Sub
        End If



        Dim dt2 As DataTable
        dt2 = cm.GetOutputTab
        cm.GetCommonParams(dt2)
		
		'''''''''''''''''''''''''''''
		
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=400 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")

        If dt.Rows.Count > 0 Then
            AddValue(dt2, dt, "Расход на трубопроводе В1.ЭН", "V1", "206")
            AddValue(dt2, dt, "Давление перед фильтром 3.1", "V2", "207")
            AddValue(dt2, dt, "Давление перед фильтром 3.2", "V3", "208")
            AddValue(dt2, dt, "Давление перед фильтром 3.3", "V4", "209")
            AddValue(dt2, dt, "Расход на трубопроводе В1.ЭН", "V5", "210")
            AddValue(dt2, dt, "Давление перед фильтром 3.4", "V6", "211")


            AddValue(dt2, dt, "Давление перед фильтром 3.5", "M1", "212")

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
        Dim T202 As UShort
        Dim T203 As UShort
        Dim T211 As UShort
        Dim T212 As UShort


        '''''''''''''''''''''''''''''''  "ЦВО_ШУ_1"

        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=392 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
        If dt.Rows.Count > 0 Then
            If Not (TypeOf (dt.Rows(0)("T1")) Is DBNull) Then
                T0 = CType(dt.Rows(0)("T1"), UShort)
            Else
                T0 = 0
            End If

            If Not (TypeOf (dt.Rows(0)("T2")) Is DBNull) Then
                T202 = CType(dt.Rows(0)("T2"), UShort)
            Else
                T202 = 0
            End If

            If Not (TypeOf (dt.Rows(0)("T3")) Is DBNull) Then
                T203 = CType(dt.Rows(0)("T3"), UShort)
            Else
                T203 = 0
            End If

            If Not (TypeOf (dt.Rows(0)("T4")) Is DBNull) Then
                T211 = CType(dt.Rows(0)("T4"), UShort)
            Else
                T211 = 0
            End If
            If Not (TypeOf (dt.Rows(0)("T5")) Is DBNull) Then
                T212 = CType(dt.Rows(0)("T5"), UShort)
            Else
                T212 = 0
            End If



        End If

        '3.1M1
        dr = dt2.NewRow
        dr("ID") = "84.23"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = "-"


        If cm.IsBitSet(T202, 0) Then
            If cm.IsBitSet(T0, 0) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Открыта. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Открыта. Руч."
            End If


        End If

        If cm.IsBitSet(T202, 1) Then
            If cm.IsBitSet(T0, 0) Then
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Автомат"
            Else
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Руч."
            End If


        End If

        If cm.IsBitSet(T211, 2) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)



        '3.1M2
        dr = dt2.NewRow
        dr("ID") = "84.21"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = "-"


        If cm.IsBitSet(T202, 2) Then
            If cm.IsBitSet(T0, 1) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Открыта. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Открыта. Руч."
            End If


        End If

        If cm.IsBitSet(T202, 3) Then
            If cm.IsBitSet(T0, 1) Then
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Автомат"
            Else
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Руч."
            End If


        End If

        If cm.IsBitSet(T211, 5) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)


        '3.1M3
        dr = dt2.NewRow
        dr("ID") = "84.22"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = "-"


        If cm.IsBitSet(T202, 5) Then
            If cm.IsBitSet(T0, 2) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Открыта. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Открыта. Руч."
            End If


        End If

        If cm.IsBitSet(T202, 4) Then
            If cm.IsBitSet(T0, 2) Then
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Автомат"
            Else
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Руч."
            End If


        End If

        If cm.IsBitSet(T211, 8) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)




        '3.1M4
        dr = dt2.NewRow
        dr("ID") = "84.24"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = "-"


        If cm.IsBitSet(T202, 7) Then
            If cm.IsBitSet(T0, 3) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Открыта. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Открыта. Руч."
            End If


        End If

        If cm.IsBitSet(T202, 6) Then
            If cm.IsBitSet(T0, 3) Then
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Автомат"
            Else
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Руч."
            End If


        End If

        If cm.IsBitSet(T211, 11) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)



        '3.1M5
        dr = dt2.NewRow
        dr("ID") = "84.25"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = "-"


        If cm.IsBitSet(T202, 9) Then
            If cm.IsBitSet(T0, 4) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Открыта. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Открыта. Руч."
            End If


        End If

        If cm.IsBitSet(T202, 8) Then
            If cm.IsBitSet(T0, 4) Then
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Автомат"
            Else
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Руч."
            End If


        End If

        If cm.IsBitSet(T211, 14) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)




        '3.2M1
        dr = dt2.NewRow
        dr("ID") = "84.28"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = "-"


        If cm.IsBitSet(T203, 0) Then
            If cm.IsBitSet(T0, 5) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Открыта. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Открыта. Руч."
            End If


        End If

        If cm.IsBitSet(T203, 1) Then
            If cm.IsBitSet(T0, 5) Then
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Автомат"
            Else
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Руч."
            End If


        End If

        If cm.IsBitSet(T212, 2) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)


        '3.2M2
        dr = dt2.NewRow
        dr("ID") = "84.26"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = "-"


        If cm.IsBitSet(T203, 2) Then
            If cm.IsBitSet(T0, 6) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Открыта. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Открыта. Руч."
            End If


        End If

        If cm.IsBitSet(T203, 3) Then
            If cm.IsBitSet(T0, 6) Then
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Автомат"
            Else
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Руч."
            End If


        End If

        If cm.IsBitSet(T212, 5) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)



        '3.2M3
        dr = dt2.NewRow
        dr("ID") = "84.27"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = "-"


        If cm.IsBitSet(T203, 4) Then
            If cm.IsBitSet(T0, 7) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Открыта. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Открыта. Руч."
            End If


        End If

        If cm.IsBitSet(T203, 5) Then
            If cm.IsBitSet(T0, 7) Then
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Автомат"
            Else
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Руч."
            End If


        End If

        If cm.IsBitSet(T212, 8) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)

        '3.2M4
        dr = dt2.NewRow
        dr("ID") = "84.29"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = "-"


        If cm.IsBitSet(T203, 6) Then
            If cm.IsBitSet(T0, 8) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Открыта. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Открыта. Руч."
            End If


        End If

        If cm.IsBitSet(T203, 7) Then
            If cm.IsBitSet(T0, 8) Then
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Автомат"
            Else
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Руч."
            End If


        End If

        If cm.IsBitSet(T212, 11) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)

        '3.2M5
        dr = dt2.NewRow
        dr("ID") = "84.30"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = "-"


        If cm.IsBitSet(T203, 8) Then
            If cm.IsBitSet(T0, 9) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Открыта. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Открыта. Руч."
            End If


        End If

        If cm.IsBitSet(T203, 9) Then
            If cm.IsBitSet(T0, 9) Then
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Автомат"
            Else
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Руч."
            End If


        End If

        If cm.IsBitSet(T212, 14) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)


        '''''''''''' ЦВО_ШУ_2

		  T0 =0
         T202 =0
         T203 =0
         T211 =0
         T212 =0
		
		
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=393 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
        If dt.Rows.Count > 0 Then
            If Not (TypeOf (dt.Rows(0)("T1")) Is DBNull) Then
                T0 = CType(dt.Rows(0)("T1"), UShort)
            Else
                T0 = 0
            End If

            If Not (TypeOf (dt.Rows(0)("T2")) Is DBNull) Then
                T202 = CType(dt.Rows(0)("T2"), UShort)
            Else
                T202 = 0
            End If

            If Not (TypeOf (dt.Rows(0)("T3")) Is DBNull) Then
                T203 = CType(dt.Rows(0)("T3"), UShort)
            Else
                T203 = 0
            End If

            If Not (TypeOf (dt.Rows(0)("T4")) Is DBNull) Then
                T211 = CType(dt.Rows(0)("T4"), UShort)
            Else
                T211 = 0
            End If
            If Not (TypeOf (dt.Rows(0)("T5")) Is DBNull) Then
                T212 = CType(dt.Rows(0)("T5"), UShort)
            Else
                T212 = 0
            End If



        End If




        '3.3M1
        dr = dt2.NewRow
        dr("ID") = "84.33"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = "-"


        If cm.IsBitSet(T202, 0) Then
            If cm.IsBitSet(T0, 0) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Открыта. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Открыта. Руч."
            End If


        End If

        If cm.IsBitSet(T202, 1) Then
            If cm.IsBitSet(T0, 0) Then
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Автомат"
            Else
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Руч."
            End If


        End If

        If cm.IsBitSet(T211, 2) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)




        '3.3M2
        dr = dt2.NewRow
        dr("ID") = "84.31"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = "-"


        If cm.IsBitSet(T202, 2) Then
            If cm.IsBitSet(T0, 1) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Открыта. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Открыта. Руч."
            End If


        End If

        If cm.IsBitSet(T202, 3) Then
            If cm.IsBitSet(T0, 1) Then
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Автомат"
            Else
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Руч."
            End If


        End If

        If cm.IsBitSet(T211, 5) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)



        '3.3M3
        dr = dt2.NewRow
        dr("ID") = "84.32"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = "-"


        If cm.IsBitSet(T202, 4) Then
            If cm.IsBitSet(T0, 2) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Открыта. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Открыта. Руч."
            End If


        End If

        If cm.IsBitSet(T202, 5) Then
            If cm.IsBitSet(T0, 2) Then
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Автомат"
            Else
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Руч."
            End If


        End If

        If cm.IsBitSet(T211, 8) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)


        '3.3M4
        dr = dt2.NewRow
        dr("ID") = "84.34"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = "-"


        If cm.IsBitSet(T202, 6) Then
            If cm.IsBitSet(T0, 3) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Открыта. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Открыта. Руч."
            End If


        End If

        If cm.IsBitSet(T202, 7) Then
            If cm.IsBitSet(T0, 3) Then
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Автомат"
            Else
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Руч."
            End If


        End If

        If cm.IsBitSet(T211, 11) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)


        '3.3M5
        dr = dt2.NewRow
        dr("ID") = "84.35"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = "-"


        If cm.IsBitSet(T202, 8) Then
            If cm.IsBitSet(T0, 4) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Открыта. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Открыта. Руч."
            End If


        End If

        If cm.IsBitSet(T202, 9) Then
            If cm.IsBitSet(T0, 4) Then
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Автомат"
            Else
                dr("COLOR") = ""
                dr("INFO") = "Закрыта. Руч."
            End If


        End If

        If cm.IsBitSet(T211, 14) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
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
