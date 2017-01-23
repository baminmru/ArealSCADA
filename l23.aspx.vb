Imports System.Data
Imports Newtonsoft.Json


Partial Class l23
    Inherits System.Web.UI.Page




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

		
		
        
		dim dt2 as DataTable
        dt2 = cm.GetOutputTab
		cm.GetCommonParams(dt2)
        Dim dr As DataRow
        Dim v As UShort
        Dim T0 As UShort
		Dim T201 As UShort
        Dim T203 As UShort
        Dim T204 As UShort
		Dim T100 As UShort
        Dim T250 As UShort

		dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 AND id_bd=389 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")

        If dt.Rows.Count > 0 Then
            If Not (TypeOf (dt.Rows(0)("T1")) Is DBNull) Then
                T0 = CType(dt.Rows(0)("T1"), UShort)
            Else
                T0 = 0
            End If

            If Not (TypeOf (dt.Rows(0)("T2")) Is DBNull) Then
                T201 = CType(dt.Rows(0)("T2"), UShort)
            Else
                T201= 0
            End If

            If Not (TypeOf (dt.Rows(0)("T3")) Is DBNull) Then
                T203 = CType(dt.Rows(0)("T3"), UShort)
            Else
                T203 = 0
            End If

            If Not (TypeOf (dt.Rows(0)("T4")) Is DBNull) Then
                T204 = CType(dt.Rows(0)("T4"), UShort)
            Else
                T204 = 0
            End If
            If Not (TypeOf (dt.Rows(0)("T5")) Is DBNull) Then
                T100= CType(dt.Rows(0)("T5"), UShort)
            Else
                T100 = 0
            End If

            If Not (TypeOf (dt.Rows(0)("T6")) Is DBNull) Then
                T250 = CType(dt.Rows(0)("T6"), UShort)
            Else
                T250 = 0
            End If

        End If

       



        dr =dt2.NewRow
		dr("ID")="3.1"
		dr("COLOR")=""
		dr("BLINK")="NO"


        If cm.IsBitSet(T0, 1) Then
            If cm.IsBitSet(T0, 5) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Авт."
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
            If cm.IsBitSet(T0, 5) Then
                dr("INFO") = "Авт."
            Else
                dr("INFO") = "Руч."
            End If
          
        End If

        If cm.IsBitSet(T0, 2) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)


        dr = dt2.NewRow
        dr("ID") = "3.2"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        If cm.IsBitSet(T0, 3) Then
            If cm.IsBitSet(T0, 5) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Авт."
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		
		else
            If cm.IsBitSet(T0, 5) Then
                dr("INFO") = "Авт."
            Else
                dr("INFO") = "Руч."
            End If
          
        End If
        If cm.IsBitSet(v, 4) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If


        dt2.Rows.Add(dr)


        dr = dt2.NewRow
        dr("ID") = "3.50"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
		dr("INFO") = "0"
		
        If cm.IsBitSet(T0, 8) Then
            dr("INFO") = "1"
        End If

        If cm.IsBitSet(T0, 9) Then
            dr("INFO") = "2"
        End If
        If cm.IsBitSet(T0, 10) Then
            dr("INFO") = "3"
        
        End If
		If cm.IsBitSet(T0, 11) Then
            dr("INFO") = "4"
        End If
		If cm.IsBitSet(T201, 0) Then
            dr("INFO") = "5"
        End If

        dt2.Rows.Add(dr)



        dr = dt2.NewRow
        dr("ID") = "3.71"
        dr("COLOR") = ""
        dr("BLINK") = "NO"


        dr("INFO") = ""
        If cm.IsBitSet(T201, 3) Then
            dr("INFO") = "Открыта"
            dr("COLOR") = "GREEN"
        End If

        If cm.IsBitSet(T201, 4) Then
            dr("INFO") = "Закрыта"
        End If

        If cm.IsBitSet(T201, 1) Then
            dr("COLOR") = "YELLOW"
            dr("INFO") = dr("INFO") + " Перегрев"
        End If
        If cm.IsBitSet(T201, 2) Then
            dr("COLOR") = "RED"
            dr("INFO") = dr("INFO") + " Авария"
            dr("BLINK") = "YES"
        End If


        dt2.Rows.Add(dr)



        dr = dt2.NewRow
        dr("ID") = "3.72"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = ""
        If cm.IsBitSet(T201, 7) Then
            dr("INFO") = "Открыта"
            dr("COLOR") = "GREEN"
        End If

        If cm.IsBitSet(T201, 8) Then
            dr("INFO") = "Закрыта"
        End If

        If cm.IsBitSet(T201, 5) Then
            dr("COLOR") = "YELLOW"
            dr("INFO") = dr("INFO") + ". Перегрев"
        End If
		
        If cm.IsBitSet(T201, 6) Then
            dr("COLOR") = "RED"
            dr("INFO") = dr("INFO") + ". Авария"
            dr("BLINK") = "YES"
        End If
        dt2.Rows.Add(dr)



        dr = dt2.NewRow
        dr("ID") = "3.11"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        
		dr("INFO") = T203.ToString()
	
        dt2.Rows.Add(dr)



        dr = dt2.NewRow
        dr("ID") = "3.12"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
        dr("INFO") = T204.ToString()
        dt2.Rows.Add(dr)


        dr = dt2.NewRow
        dr("ID") = "3.21"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
		dr("INFO") = "-"
		
        If cm.IsBitSet(T100, 2) Then
            dr("INFO") = "Открыть 1.1M1"
            dr("COLOR") = "GREEN"
        End If

        If cm.IsBitSet(T100, 3) Then
            dr("INFO") = "Закрыть 1.1M1"
            dr("COLOR") = "YELLOW"
        End If
        dt2.Rows.Add(dr)

		
        dr = dt2.NewRow
        dr("ID") = "3.22"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
		dr("INFO") = "-"
        If cm.IsBitSet(T100, 4) Then
            dr("INFO") = "Открыть 1.1M2"
            dr("COLOR") = "GREEN"
        End If

        If cm.IsBitSet(T100, 5) Then
            dr("INFO") = "Закрыть 1.1M2"
            dr("COLOR") = "YELLOW"
        End If
        dt2.Rows.Add(dr)

        dr = dt2.NewRow
        dr("ID") = "3.23"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
		dr("INFO") = "-"
		
        If cm.IsBitSet(T100, 6) Then
            dr("INFO") = "Пуск УПП 1M1"
            dr("COLOR") = "YELLOW"
        End If

        If cm.IsBitSet(T100, 0) Then
            dr("INFO") = "В работе УПП 1M1"
            dr("COLOR") = "GREEN"
        End If
		
        dt2.Rows.Add(dr)


        dr = dt2.NewRow
        dr("ID") = "3.24"
        dr("COLOR") = ""
        dr("BLINK") = "NO"
		dr("INFO") = "-"
        If cm.IsBitSet(T100, 7) Then
            dr("INFO") = "Пуск УПП 1M2"
            dr("COLOR") = "YELLOW"
        End If

        If cm.IsBitSet(T100, 1) Then
            dr("INFO") = "В работе УПП 1M2"
            dr("COLOR") = "GREEN"
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
