Imports System.Data
Imports Newtonsoft.Json


Partial Class l29
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
		
		
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 AND id_bd=400 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")

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
		Dim T100 As UShort
		Dim T201 As UShort
        Dim T211 As UShort
		
		''''''''''''''''' подсистема 1
		
        '''''''''''''''''''''''''''''''  "ЦМО_ШУ_19"
		 T0 =0
         T100 =0
		 T201 =0
         T211 =0
		 
		dr = dt2.NewRow
        dr("ID") = "9.1.1"
        dr("COLOR") = "GREEN"
        dr("BLINK") = "NO"
        dr("INFO") = " OK"
		 
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 AND id_bd=405 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
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
		else
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"	
        End If

        
        If cm.IsBitSet(T211, 1) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T211, 3) Then
            dr("COLOR") = "RED"
			dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If
		
		dt2.Rows.Add(dr)
		 
		dr = dt2.NewRow
        dr("ID") = "9.1.2"
        dr("COLOR") = "GREEN"
        dr("BLINK") = "NO"
        dr("INFO") = " OK"
		
		if dt.Rows.Count=0 then
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"
		end if



        If cm.IsBitSet(T211, 5) Then
            dr("COLOR") = "RED"
          	dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T211, 7) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)

		''''''''''''''' Подсистема 2
		


        '''''''''''''''''''''''''''''''  "ЦМО_ШУ_20"
		 T0 =0
         T100 =0
		 T201 =0
         T211 =0
		 
		
        dr = dt2.NewRow
        dr("ID") = "9.2"
        dr("COLOR") = "GREEN"
        dr("BLINK") = "NO"
        dr("INFO") = " OK"

		 
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 AND id_bd=406 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
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
		else
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"
        End If




        '1M1
        dr = dt2.NewRow
        dr("ID") = "9.2"
        dr("COLOR") = "GREEN"
        dr("BLINK") = "NO"
        dr("INFO") = " OK"

      	if dt.Rows.Count=0 then
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"
		end if


        If cm.IsBitSet(T100, 1) Then
            dr("COLOR") = "RED"
		 dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If


        If cm.IsBitSet(T100, 3) Then
            dr("COLOR") = "RED"
			 dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)
		
		
		'''''''''''''' Подсистема 3 + 5 
		
		'''''''''''''''''''''''''''''''  "ЦМО_ШУ_21"
		 T0 =0
         T100 =0
		 T201 =0
         T211 =0

      
        dr = dt2.NewRow
        dr("ID") = "9.3.1"
        dr("COLOR") = "GREEN"
        dr("BLINK") = "NO"
        dr("INFO") = " OK"
		
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
		else
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"
        End If



        If cm.IsBitSet(T100, 1) Then
            dr("COLOR") = "RED"
			 dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T100, 3) Then
            dr("COLOR") = "RED"
			 dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)
		
		
		 dr = dt2.NewRow
        dr("ID") = "9.3.2"
        dr("COLOR") = "GREEN"
        dr("BLINK") = "NO"
        dr("INFO") = " OK"
		
		if dt.Rows.Count=0 then
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"
		end if

        If cm.IsBitSet(T100, 1) Then
            dr("COLOR") = "RED"
			 dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T100, 3) Then
            dr("COLOR") = "RED"
			 dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)
		
		
		
		'''''''''''''''''  подсистема 5
		
		
		  '1M3
        dr = dt2.NewRow
        dr("ID") = "9.5"
        dr("COLOR") = "GREEN"
        dr("BLINK") = "NO"
        dr("INFO") = " OK"
		
		if dt.Rows.Count=0 then
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"
		end if

        If cm.IsBitSet(T100, 5) Then
            dr("COLOR") = "RED"
			dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T211, 1) Then
            dr("COLOR") = "RED"
			dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T211, 3) Then
            dr("COLOR") = "RED"
			dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        
        If cm.IsBitSet(T211, 5) Then
            dr("COLOR") = "RED"
			dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)
		
		
		''''''''''' подсистема 4
		
		
        '''''''''''''''''''''''''''''''  "ЦМО_ШУ_22"
	 T0 =0
         T100 =0
		 T201 =0
         T211 =0
		 
		 dr = dt2.NewRow
        dr("ID") = "9.4"
        dr("COLOR") = "GREEN"
        dr("BLINK") = "NO"
        dr("INFO") = " OK"

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

		if dt.Rows.Count=0 then
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"
		end if

        If cm.IsBitSet(T0, 11) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)


       ''''''''''''''''' подсистема 6
	   
	    '''''''''''''''''''''''''''''''  "ЦМО_ШУ_23"
	     T0 =0
         T100 =0
		 T201 =0
         T211 =0
		 
		dr = dt2.NewRow
        dr("ID") = "9.6"
        dr("COLOR") = "GREEN"
        dr("BLINK") = "NO"
        dr("INFO") = " OK"

		
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 AND id_bd=409 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
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

		if dt.Rows.Count=0 then
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"
		end if
     

        If cm.IsBitSet(T100, 1) Then
            dr("COLOR") = "RED"
			 dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T100, 3) Then
            dr("COLOR") = "RED"
			 dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)
		
		
		'''''''''''''''  final

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
