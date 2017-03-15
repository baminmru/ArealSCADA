Imports System.Data
Imports Newtonsoft.Json


Partial Class l1
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


       
        Dim dt2 as DataTable
		Dim dr As DataRow
        Dim v As UShort
        Dim T0 As UShort
		Dim T201 As UShort
		Dim T100 As UShort
        Dim T202 As UShort
        Dim T203 As UShort
        Dim T204 As UShort
		Dim T211 As UShort
		Dim T212 As UShort
        Dim T250 As UShort
        
		

        dt2 = cm.GetOutputTab
        cm.GetCommonParams(dt2)
		
		
		'''' L3
		
		 T0 =0
		 T201 =0
		 T100 =0
         T202 =0
         T203 =0
         T204 =0
		 T211 =0
		 T212 =0
         T250 =0
			dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=389 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")

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
		dr("ID")="3"
		dr("COLOR")="GREEN"
		dr("BLINK")="NO"
		dr("INFO") = " OK"

		if dt.Rows.Count=0 then
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"
		end if
     
        If cm.IsBitSet(T0, 2) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

       
        If cm.IsBitSet(T0, 4) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

       
        
        If cm.IsBitSet(T201, 2) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

		
        If cm.IsBitSet(T201, 6) Then
            dr("COLOR") = "RED"
           dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If
		
		
		
        dt2.Rows.Add(dr)

		''''''''''''''''''''''''''''''''''' L4
		T0 =0
		 T201 =0
		 T100 =0
         T202 =0
         T203 =0
         T204 =0
		 T211 =0
		 T212 =0
         T250 =0
		
		dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=401 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")

		
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
                T202 = CType(dt.Rows(0)("T3"), UShort)
            Else
                T202 = 0
            End If

			
			
            If Not (TypeOf (dt.Rows(0)("T4")) Is DBNull) Then
                T211 = CType(dt.Rows(0)("T4"), UShort)
            Else
                T211 = 0
            End If
            

        End If


        dr = dt2.NewRow
        dr("ID") = "4"
        dr("COLOR") = "GREEN"
        dr("BLINK") = "NO"
		dr("INFO") = " OK"
		
		

      	if dt.Rows.Count=0 then
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"
		end if
		
		If cm.IsBitSet(T0, 7) Then
			dr("COLOR") = "RED"
            dr("INFO") = " Авария"
			 dr("BLINK") = "YES"
        End If

       
		
		If cm.IsBitSet(T0, 11) Then
			dr("COLOR") = "RED"
            dr("INFO") = " Авария"
			 dr("BLINK") = "YES"
        End If

		
		If cm.IsBitSet(T202, 4) Then
			dr("COLOR") = "RED"
            dr("INFO") = " Авария"
			 dr("BLINK") = "YES"
        End If

		
		'If cm.IsBitSet(T202, 9) Then
		'	dr("COLOR") = "RED"
        '    dr("INFO") = " Авария"
		'	 dr("BLINK") = "YES"
        'End If

        dt2.Rows.Add(dr)
		
		

		''''''''''''''''''''''''''''''''''''''''''''''''' L8
		T0 =0
		 T201 =0
		 T100 =0
         T202 =0
         T203 =0
         T204 =0
		 T211 =0
		 T212 =0
         T250 =0
     

        dr = dt2.NewRow
        dr("ID") = "8"
        dr("COLOR") = "GREEN"
        dr("BLINK") = "NO"
        dr("INFO") = " OK"
		
	    '''''''''''''''''''''''''''''''''' ШМ
		  dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=400 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
        If dt.Rows.Count = 0 Then
			 if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"
		end if

		
        '''''''''''''''''''''''''''''''  "ЦВО_ШУ_12"
		T0 =0
		 T201 =0
		 T100 =0
         T202 =0
         T203 =0
         T204 =0
		 T211 =0
		 T212 =0
         T250 =0
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=397 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
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
                T211 = CType(dt.Rows(0)("T3"), UShort)
            Else
                T211 = 0
            End If
        End If
		
		if dt.Rows.Count=0 then
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"
		end if
		
        '1M
        If cm.IsBitSet(T211, 2) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If
        '2M
        If cm.IsBitSet(T211, 5) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If
        If cm.IsBitSet(T211, 8) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If
        If cm.IsBitSet(T211, 11) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If
        If cm.IsBitSet(T211, 14) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If
		
        '''''''''''''''''''''''''''''''  "ЦВО_ШУ_13"
		 T0 =0
		 T201 =0
		 T100 =0
         T202 =0
         T203 =0
         T204 =0
		 T211 =0
		 T212 =0
         T250 =0
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=398 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
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
		
		
		
		 If cm.IsBitSet(T100, 5) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If
		
		
		   '''''''''''''''''''''''''''''''  "ЦВО_ШУ_14"
		 T0 =0
         T202 =0
         T211 =0
         T100 =0
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=399 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
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
		
		
		
		 If cm.IsBitSet(T100, 5) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If
		
		'''''''''''''''  подсистема 2
		
		 '''''''''''''''''''''''''''''''  "ЦВО_ШУ_17"
		T0 =0
		 T201 =0
		 T100 =0
         T202 =0
         T203 =0
         T204 =0
		 T211 =0
		 T212 =0
         T250 =0
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=402 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")


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

		
		
		'''''''''''''''  подсистема 3
		
		'''''''''''''''''''''''''''''''  "ЦВО_ШУ_18"
         T0 =0
         T202 =0
		 T203 =0
         T211 =0
		 T212 =0
         T100 =0
		 
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
		else
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"			
        End If
	
        If cm.IsBitSet(T100, 1) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
	
        End If
    

        If cm.IsBitSet(T100, 3) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
        End If
       

        If cm.IsBitSet(T100, 5) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
        End If
       

        If cm.IsBitSet(T211, 1) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
		
        End If
     

        If cm.IsBitSet(T211, 3) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
		
        End If
       

        If cm.IsBitSet(T211, 5) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
        End If
      

        If cm.IsBitSet(T211, 7) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
        End If
       
        If cm.IsBitSet(T211, 9) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
        End If
      

        If cm.IsBitSet(T211, 11) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
		
        End If
       

        If cm.IsBitSet(T211, 13) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
        End If
     

        If cm.IsBitSet(T211, 15) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
        End If
    
        If cm.IsBitSet(T212, 1) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
        End If
    

        If cm.IsBitSet(T212, 3) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
        End If
    

        If cm.IsBitSet(T212, 5) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
        End If
       

        If cm.IsBitSet(T212, 7) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
        End If
      

        If cm.IsBitSet(T212, 9) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
        End If
       

        If cm.IsBitSet(T212, 11) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
        End If
      

        If cm.IsBitSet(T212, 13) Then
            dr("COLOR") = "RED"
            dr("BLINK") = "YES"
			dr("INFO") = " Авария"
        End If
      
		
		'''''''''''  Подсистема 4
		
		 '''''''''''''''''''''''''''''''  "ЦВО_ШУ_1"
		 T0 =0
         T202 =0
		 T203 =0
         T211 =0
		 T212 =0
         T100 =0
		 
		
		
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

		else
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"

        End If

       
      

        If cm.IsBitSet(T211, 2) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

     

        If cm.IsBitSet(T211, 5) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

      

        If cm.IsBitSet(T211, 8) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If


        If cm.IsBitSet(T211, 11) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T211, 14) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If


        If cm.IsBitSet(T212, 2) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If


        If cm.IsBitSet(T212, 5) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T212, 8) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T212, 11) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

       

        If cm.IsBitSet(T212, 14) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

      


        '''''''''''' ЦВО_ШУ_2
		T0 =0
         T202 =0
		 T203 =0
         T211 =0
		 T212 =0
         T100 =0
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
		else
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"			
        End If


        If cm.IsBitSet(T211, 2) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If


        If cm.IsBitSet(T211, 5) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If


        If cm.IsBitSet(T211, 8) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T211, 11) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If


        If cm.IsBitSet(T211, 14) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

     

		
		'''''''''''''''''' Подсистема 5 
		
		 '''''''''''''''''''''''''''''''  "ЦВО_ШУ_2"
		T0 =0
         T202 =0
		 T203 =0
         T211 =0
		 T212 =0
         T100 =0
		 
	
		
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


		else
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"
        End If

       
       

        
        If cm.IsBitSet(T212, 2) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T212, 5) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T212, 8) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T212, 11) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T212, 14) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        '''''''''''' ЦВО_ШУ_3

		 T0 =0
         T202 =0
		 T203 =0
         T211 =0
		 T212 =0
         T100 =0
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=394 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
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

		else
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"

        End If

        If cm.IsBitSet(T211, 2) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T211, 5) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T211, 8) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T211, 11) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T211, 14) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T212, 2) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If


        If cm.IsBitSet(T212, 5) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T212, 8) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T212, 11) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        If cm.IsBitSet(T212, 14) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

      
		
		
		''''''''''''''' Подсистема 6 '''''''''
		
		'''''''''''''''''''''''''''''''  "ЦВО_ШУ_4"
		 T0 =0
         T202 =0
		 T203 =0
         T211 =0
		 T212 =0
         T100 =0
		 
	
		 
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=395 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
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

        If cm.IsBitSet(T0, 9) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

        '''''''''''''''''''''''''''''''  "ЦВО_ШУ_8"
		T0 =0
         T202 =0
		 T203 =0
         T211 =0
		 T212 =0
         T100 =0
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=396 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
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


        If cm.IsBitSet(T0, 9) Then
            dr("COLOR") = "RED"
            dr("INFO") = "Авария"
            dr("BLINK") = "YES"
        End If

        dt2.Rows.Add(dr)
		
		
		''''''''''''''''''''''''''''''''''''' L9
		
		''''''''''''''''' подсистема 1
		
        '''''''''''''''''''''''''''''''  "ЦМО_ШУ_19"
		T0 =0
		 T201 =0
		 T100 =0
         T202 =0
         T203 =0
         T204 =0
		 T211 =0
		 T212 =0
         T250 =0
		 
		dr = dt2.NewRow
        dr("ID") = "9"
        dr("COLOR") = "GREEN"
        dr("BLINK") = "NO"
        dr("INFO") = " OK"
		 dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=404 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
		 If dt.Rows.Count = 0 Then
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"
		 end if
		
		
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


		if dt.Rows.Count=0 then
		  if dr("COLOR") = "GREEN" then dr("COLOR") = "YELLOW"
		  if dr("INFO") = " OK" then dr("INFO") = " Нет данных"
		end if

        
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

        If cm.IsBitSet(T211, 7) Then
            dr("COLOR") = "RED"
            dr("INFO") = " Авария"
            dr("BLINK") = "YES"
        End If

     

		''''''''''''''' Подсистема 2
		


        '''''''''''''''''''''''''''''''  "ЦМО_ШУ_20"
T0 =0
		 T201 =0
		 T100 =0
         T202 =0
         T203 =0
         T204 =0
		 T211 =0
		 T212 =0
         T250 =0
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=406 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
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

		
		'''''''''''''' Подсистема 3 + 5 
		
		'''''''''''''''''''''''''''''''  "ЦМО_ШУ_21"
T0 =0
		 T201 =0
		 T100 =0
         T202 =0
         T203 =0
         T204 =0
		 T211 =0
		 T212 =0
         T250 =0
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=407 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
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

		
		
		'''''''''''''''''  подсистема 5
	

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

      
		''''''''''' подсистема 4
		
		
        '''''''''''''''''''''''''''''''  "ЦМО_ШУ_22"
		T0 =0
		 T201 =0
		 T100 =0
         T202 =0
         T203 =0
         T204 =0
		 T211 =0
		 T212 =0
         T250 =0
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=408 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
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
		
		
		dr = dt2.NewRow
        dr("ID") = "12"
        dr("COLOR") = "GREEN"
        dr("BLINK") = "NO"
        dr("INFO") = " OK"
		
		
       ''''''''''''''''' подсистема 6
	   
	    '''''''''''''''''''''''''''''''  "ЦМО_ШУ_23"
T0 =0
		 T201 =0
		 T100 =0
         T202 =0
         T203 =0
         T204 =0
		 T211 =0
		 T212 =0
         T250 =0
        dt = cm.QuerySelect(" SELECT * FROM datacurr WHERE id_ptype =1 and T1 is not null AND id_bd=409 AND dcounter >SYSDATE-1/24/12 order BY dcounter desc")
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
		
		
		''''''''''''   Final level1

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
