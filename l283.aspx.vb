Imports System.Data
Imports Newtonsoft.Json


Partial Class l283
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
 cm.Close()
            Exit Sub
        End If


        Dim dt2 As DataTable
        dt2 = cm.GetOutputTab
        cm.GetCommonParams(dt2)

        Dim dr As DataRow
        Dim v As UShort
        Dim T0 As UShort
        Dim T202 As UShort
		Dim T203 As UShort
        Dim T211 As UShort
		Dim T212 As UShort
        Dim T100 As UShort


        '''''''''''''''''''''''''''''''  "ЦВО_ШУ_18"
     
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=403 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
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
			
			If Not (TypeOf (dt.Rows(0)("T6")) Is DBNull) Then
                T100 = CType(dt.Rows(0)("T6"), UShort)
            Else
                T100 = 0
            End If
        End If
		
		
		
		dr = dt2.NewRow
        dr("ID") = "83.21"
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
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T100, 1) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T0, 0) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
        End If
        dt2.Rows.Add(dr)
		
		
		
		dr = dt2.NewRow
        dr("ID") = "83.22"
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
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T100, 3) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T0, 2) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
        End If
        dt2.Rows.Add(dr)
		
		
		dr = dt2.NewRow
        dr("ID") = "83.23"
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
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T100, 5) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T0, 4) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
        End If
        dt2.Rows.Add(dr)
		
		
		dr = dt2.NewRow
        dr("ID") = "83.24"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"


        If cm.IsBitSet(T202, 1) Then
            If cm.IsBitSet(T202, 0) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
		  If cm.IsBitSet(T202,0) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T211, 1) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T202, 0) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
        End If
        dt2.Rows.Add(dr)
		
		
		dr = dt2.NewRow
        dr("ID") = "83.25"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"


        If cm.IsBitSet(T202, 3) Then
            If cm.IsBitSet(T202, 2) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
		  If cm.IsBitSet(T202, 2) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T211, 3) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T202, 2) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
        End If
        dt2.Rows.Add(dr)
		
		
		dr = dt2.NewRow
        dr("ID") = "83.26"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T202, 5) Then
            If cm.IsBitSet(T202, 4) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
		  If cm.IsBitSet(T202, 4) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T211, 5) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T202, 4) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
        End If
        dt2.Rows.Add(dr)
		
		
		dr = dt2.NewRow
        dr("ID") = "83.27"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T202, 7) Then
            If cm.IsBitSet(T202, 6) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
		  If cm.IsBitSet(T202, 6) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T211, 7) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T202, 6) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
        End If
        dt2.Rows.Add(dr)
		

		dr = dt2.NewRow
        dr("ID") = "83.28"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T202, 9) Then
            If cm.IsBitSet(T202, 8) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
		  If cm.IsBitSet(T202, 8) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T211, 9) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T202, 8) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
        End If
        dt2.Rows.Add(dr)
		
		
		dr = dt2.NewRow
        dr("ID") = "83.29"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T202, 11) Then
            If cm.IsBitSet(T202, 10) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
		  If cm.IsBitSet(T202, 10) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T211, 11) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T202, 10) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
        End If
        dt2.Rows.Add(dr)
		
		
		dr = dt2.NewRow
        dr("ID") = "83.30"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T202, 13) Then
            If cm.IsBitSet(T202, 12) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
		  If cm.IsBitSet(T202, 12) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T211, 13) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T202, 12) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
        End If
        dt2.Rows.Add(dr)
		
		
		dr = dt2.NewRow
        dr("ID") = "83.31"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T202, 15) Then
            If cm.IsBitSet(T202, 14) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
		  If cm.IsBitSet(T202, 14) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T211, 15) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T202, 14) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
        End If
        dt2.Rows.Add(dr)
		
		
		
		dr = dt2.NewRow
        dr("ID") = "83.32"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T203, 1) Then
            If cm.IsBitSet(T203, 0) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
		  If cm.IsBitSet(T203, 0) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T212, 1) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T203, 0) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
        End If
        dt2.Rows.Add(dr)
		
		
		dr = dt2.NewRow
        dr("ID") = "83.33"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T203, 3) Then
            If cm.IsBitSet(T203, 2) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
		  If cm.IsBitSet(T203, 2) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T212, 3) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T203, 2) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
        End If
        dt2.Rows.Add(dr)
		
		dr = dt2.NewRow
        dr("ID") = "83.34"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T203, 5) Then
            If cm.IsBitSet(T203, 4) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
		  If cm.IsBitSet(T203, 4) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T212, 5) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T203, 4) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
        End If
        dt2.Rows.Add(dr)
		
		
		dr = dt2.NewRow
        dr("ID") = "83.35"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T203, 7) Then
            If cm.IsBitSet(T203, 6) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
		  If cm.IsBitSet(T203, 6) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T212, 7) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T203, 6) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
        End If
        dt2.Rows.Add(dr)
		
		
		dr = dt2.NewRow
        dr("ID") = "83.36"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T203, 9) Then
            If cm.IsBitSet(T203, 8) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
		  If cm.IsBitSet(T203, 8) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T212, 9) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T203, 8) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
        End If
        dt2.Rows.Add(dr)
		
		
		
		dr = dt2.NewRow
        dr("ID") = "83.37"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T203, 11) Then
            If cm.IsBitSet(T203, 10) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
		  If cm.IsBitSet(T203, 10) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T212, 11) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T203, 10) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
        End If
        dt2.Rows.Add(dr)
		
		
		dr = dt2.NewRow
        dr("ID") = "83.38"
        dr("COLOR") = "-"
        dr("BLINK") = "NO"
        dr("INFO") = "-"

        If cm.IsBitSet(T203, 13) Then
            If cm.IsBitSet(T203, 12) Then
                dr("COLOR") = "GREEN"
                dr("INFO") = "Работа. Автомат"
            Else
                dr("COLOR") = "YELLOW"
                dr("INFO") = "Работа. Руч."
            End If
		else
		  If cm.IsBitSet(T203, 12) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Руч."
            End If
        End If

        If cm.IsBitSet(T212, 13) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			
			 If cm.IsBitSet(T203, 12) Then
               ' dr("COLOR") = "GREEN"
                dr("INFO") = "Авария. Автомат"
            Else
                'dr("COLOR") = "YELLOW"
                dr("INFO") = "Авария. Руч."
            End If
		
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
