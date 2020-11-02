		function OpenStanze()
		 {	
			if (document.getElementById('<%=idPian.ClientID%>').value==0){
				alert("Devi selezionare un piano di un edificio!!")
				return;
			}
			var controlList='<%=ListBoxStanze.ClientID%>';
			finestra=window.open("Stanze.aspx?idbl=" + document.getElementById('<%=idEdif.ClientID%>').value + "&idpiano=" + document.getElementById('<%=idPian.ClientID%>').value + "&ctrid=" + controlList ,"stanze","resizable=yes,menubar=no,toolbar=no,location=no,status=yes,width=300,height=300");
		 }
		 
		 function OpenEqstd()
		 {
			if (document.getElementById('<%=idPian.ClientID%>').value==0){
				alert("Devi selezionare un piano di un edificio!!")
				return;
			}
			var controlList='<%=ListBoxEQSTD.ClientID%>';
			finestra2=window.open("StandardApp.aspx?idbl=" + document.getElementById('<%=idEdif.ClientID%>').value + "&idpiano=" + document.getElementById('<%=idPian.ClientID%>').value + "&ctrid=" + controlList ,"eqstd","resizable=yes,menubar=no,toolbar=no,location=no,status=yes,width=600,height=400");
		 }
		 
		 function OpenEq()
		 {
			if (document.getElementById('<%=idPian.ClientID%>').value==0){
				alert("Devi selezionare un piano di un edificio!!");
				return;
			}
			var controlList='<%=listBoxEQClId%>';
			finestra2=window.open("apparecchiature.aspx?idbl=" + 
			document.getElementById('<%=idEdif.ClientID%>').value + 
			"&idpiano=" + document.getElementById('<%=idPian.ClientID%>').value + 
			"&ctrid=" + controlList +
			"&descrizione=" + document.getElementById("filtroApp").value +
			"&idReparto=" + document.getElementById("<%=repartiDropDownList.getClientID()%>").value +
			"&idCategoria=" + document.getElementById("<%=CategorieDropDownList.getClientID()%>").value +
			"&idDestUso=" + document.getElementById("<%=destUsoDropDownList.getClientID()%>").value +
			"&stanzeSel=" + document.getElementById("hiddenStanze").value,
			"STD","resizable=yes,menubar=no,toolbar=no,location=no,status=yes,width=600,height=400");
		 }
		 
		 
		 function ValorizzaStanze(sender,sender2)
		 {
		   var ctrlLis= document.getElementById('<%=ListBoxStanze.ClientID%>');
		  	var i;
			for (i = 0; i < ctrlLis.options.length; i++) 
			{
				
				if(ctrlLis.options[i].value==sender)
				{
					alert("Stanza già inserito!");
					finestra.focus();
					return;
				}
				if(ctrlLis.options[i].value=="")
				  ctrlLis.options[i]=null;
			}
			var opt= new Option(sender2,sender);
			var lenoption=ctrlLis.options.length;
            ctrlLis.options[lenoption]=opt;
            var hiddenctrl=document.getElementById('<%=hiddenStanze.ClientID%>');
            ReloadHidden(hiddenctrl,ctrlLis);
            var hiddenctrl2=document.getElementById('<%=stanzeDescription.ClientID%>');
            ReloadHidden2(hiddenctrl2,ctrlLis);
           
		 }
		 
		 function ValorizzaEqstd(sender,sender2)
		 {
		   var ctrlLis= document.getElementById('<%=ListBoxEQSTD.ClientID%>');
		  	var i;
			for (i = 0; i < ctrlLis.options.length; i++) 
			{
				
				if(ctrlLis.options[i].value==sender)
				{
					alert("Standard Apparechiatura già inserito!");
					finestra2.focus();
					return;
				}
				if(ctrlLis.options[i].value=="")
				  ctrlLis.options[i]=null;
			}
			var opt= new Option(sender2,sender);
			var lenoption=ctrlLis.options.length;
            ctrlLis.options[lenoption]=opt;
            var hiddenctrl=document.getElementById('<%=hiddenEqstd.ClientID%>');
            ReloadHidden(hiddenctrl,ctrlLis);
             var hiddenctrl2=document.getElementById('<%=eqStdDescription.ClientID%>');
            ReloadHidden2(hiddenctrl2,ctrlLis);
		 }
		 
		 function ValorizzaEq(sender,sender2)
		 {
		   var ctrlLis= document.getElementById('<%=listBoxEQClId%>');
		  	var i;
			for (i = 0; i < ctrlLis.options.length; i++) 
			{
				
				if(ctrlLis.options[i].value==sender)
				{
					alert("Apparechiatura già inserita!");
					finestra2.focus();
					return;
				}
				if(ctrlLis.options[i].value=="")
				  ctrlLis.options[i]=null;
			}
			var opt= new Option(sender2,sender);
			var lenoption=ctrlLis.options.length;
            ctrlLis.options[lenoption]=opt;
            
            var hiddenctrl=document.getElementById('<%=hiddenEq.ClientID%>');
            ReloadHidden(hiddenctrl,ctrlLis);
            var hiddenctrl2=document.getElementById('<%=eqDescription.ClientID%>');
            ReloadHidden2(hiddenctrl2,ctrlLis);
		 }
		 
		function deleteitem(sender,e)
		{
			if (sender.selectedIndex!=-1) 
			{ 
				if ((event.keyCode==46) && (window.confirm('Eliminare l\'elemento selezionato?')))
				{
					if (sender.options.length!=0) 
						sender.options[sender.selectedIndex]=null;
				}
				if (sender.options.length==0) {
					//alert("pippo");
					/*if(sender ==document.getElementById('<%=ListBoxEQSTD.ClientID%>'))
						document.getElementById('<%=ListBoxEQSTD.ClientID%>').options[0]=new Option("","- Tutti gli Standard Apparechiatura -");
					else if(sender ==document.getElementById('<%=listBoxEQ.ClientID%>'))
						document.getElementById('<%=listBoxEQClId%>').options[0]=new Option("","- Tutte le Apparechiature -");
					else*/
						//sender.options[0]=new Option("","- Tutte le Stanze -");
				}
			} 
			var hiddenctrl=null;
			if(sender ==document.getElementById('<%=ListBoxEQSTD.ClientID%>'))
			   hiddenctrl=document.getElementById('<%=hiddenEqstd.ClientID%>');
			else if(sender ==document.getElementById('<%=listBoxEQ.ClientID%>'))
			   hiddenctrl=document.getElementById('<%=hiddenEq.ClientID%>');
			else
			   hiddenctrl=document.getElementById('<%=hiddenStanze.ClientID%>');
			   
			ReloadHidden(hiddenctrl,sender);
			
			hiddenctrl=null;
			if(sender ==document.getElementById('<%=ListBoxEQSTD.ClientID%>'))
			   hiddenctrl=document.getElementById('<%=eqStdDescription.ClientID%>');
			else if(sender ==document.getElementById('<%=listBoxEQ.ClientID%>'))
			   hiddenctrl=document.getElementById('<%=eqDescription.ClientID%>');
			else
			   hiddenctrl=document.getElementById('<%=stanzeDescription.ClientID%>');
			   
			ReloadHidden(hiddenctrl,sender);
		}
				
		function ReloadHidden(sender,ctrlLis)
		{
			var hidden=sender;
            hidden.value="";
            for(i=0;i<=ctrlLis.options.length-1;i++)
            {
             if(hidden.value=="")
				hidden.value=ctrlLis.options[i].value;
			 else
			   hidden.value+="," + ctrlLis.options[i].value;
            }
		}	
		
		function ReloadHidden2(sender,ctrlLis)
		{
			var hidden=sender;
            hidden.value="";
            for(i=0;i<=ctrlLis.options.length-1;i++)
            {
             if(hidden.value=="")
				hidden.value=ctrlLis.options[i].text;
			 else
			   hidden.value+="," + ctrlLis.options[i].text;
            }
		}
			
		 function chiudi()
		 {
		  if (finestra!=null)
		      finestra.close();
		      
		  if (finestra2!=null)
		      finestra2.close();
		  
		 }
		 	function OnDivScroll(sender)
			{
				var lstCollegeNames = sender;
				if (lstCollegeNames.options.length > 8)
				{
					lstCollegeNames.size=lstCollegeNames.options.length;
				}
				else
				{
					lstCollegeNames.size=8;
				}
			}
			

			function OnSelectFocus(sender,sender2)
			{
				
				if (sender2.scrollLeft != 0)
				{
					sender2.scrollLeft = 0;
				}
				var lstCollegeNames = sender;
				if( lstCollegeNames.options.length > 8)
				{
	 				lstCollegeNames.focus();
	 				lstCollegeNames.size=8;
				}
			}
			function InviaServizi()
			{
			 var selezionati=new Array();
			 var table= document.getElementById("CheckBoxServizi")
			 var cells = table.getElementsByTagName("td");
			 var ctlr;
			 var j=0;
			 for (var i = 0; i < cells.length; i++){
				ctrl = cells[i].firstChild;
				if (ctrl.type == 'checkbox')
					if(ctrl.checked==true)
					{
						ctrl = cells[i].lastChild;
						selezionati[j]=ctrl.innerText;
						j+=1;
					}
			 }
			  
			 if(selezionati.length>0)
					alert(selezionati.toString());
			
			}
			function Inviabj(sender)
			{
			    var ctrlLis=document.getElementById(sender);
			    var message="";
				for(i=0;i<=ctrlLis.options.length-1;i++)
				{
				  message += ctrlLis.options[i].text + " ";
				}
				//alert(message);
			}	
