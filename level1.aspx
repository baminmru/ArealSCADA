﻿<%@ Page  %>
<!DOCTYPE html ">
<html>
<head>
	<meta charset="UTF-8">
	<title>Каменогорск. Главный экран</title>
	<link rel="stylesheet" href="/leaflet.css" />
	<link rel="stylesheet" href="/css/areal.css" />
	<script src="/leaflet.js" type="text/javascript"></script>
	<script src="./dist/PruneCluster.js" type="text/javascript"></script>
	<script src="./layer/Marker.Text.js" type="text/javascript"></script>
	<script src="./jquery-2.1.1.min.js" type="text/jscript"></script>
	
	<script src="./draw/src/leaflet.circle.topolygon-src.js"></script>
	<script src="./draw/src/Leaflet.draw.js"></script>
    <script src="./draw/src/Leaflet.Draw.Event.js"></script>
    <link rel="stylesheet" href="./draw/src/leaflet.draw.css"/>

    <script src="./draw/src/Toolbar.js"></script>
    <script src="./draw/src/Tooltip.js"></script>

    <script src="./draw/src/ext/GeometryUtil.js"></script>
    <script src="./draw/src/ext/LatLngUtil.js"></script>
    <script src="./draw/src/ext/LineUtil.Intersect.js"></script>
    <script src="./draw/src/ext/Polygon.Intersect.js"></script>
    <script src="./draw/src/ext/Polyline.Intersect.js"></script>
    <script src="./draw/src/ext/TouchEvents.js"></script>

    <script src="./draw/src/draw/DrawToolbar.js"></script>
    <script src="./draw/src/draw/handler/Draw.Feature.js"></script>
    <script src="./draw/src/draw/handler/Draw.SimpleShape.js"></script>
    <script src="./draw/src/draw/handler/Draw.Polyline.js"></script>
    <script src="./draw/src/draw/handler/Draw.Circle.js"></script>
    <script src="./draw/src/draw/handler/Draw.Marker.js"></script>
    <script src="./draw/src/draw/handler/Draw.Polygon.js"></script>
    <script src="./draw/src/draw/handler/Draw.Rectangle.js"></script>


    <script src="./draw/src/edit/EditToolbar.js"></script>
    <script src="./draw/src/edit/handler/EditToolbar.Edit.js"></script>
    <script src="./draw/src/edit/handler/EditToolbar.Delete.js"></script>

    <script src="./draw/src/Control.Draw.js"></script>

    <script src="./draw/src/edit/handler/Edit.Poly.js"></script>
    <script src="./draw/src/edit/handler/Edit.SimpleShape.js"></script>
    <script src="./draw/src/edit/handler/Edit.Circle.js"></script>
    <script src="./draw/src/edit/handler/Edit.Rectangle.js"></script>
    <script src="./draw/src/edit/handler/Edit.Marker.js"></script>
	
	<script src="./dist/easy-button.js" type="text/javascript"></script>
	<link rel="stylesheet" href="./dist/easy-button.css"/>
	<script src="./dist/jQuery.print.js" type="text/javascript"></script>
	
</head>
<body oncontextmenu="return false">
	<div style="position:absolute; top:0px; left:0px; height:30px; width:1000px; background: #bfbfbf; padding:10px; overflow-y: scroll;" id="brief"><table border="0"><tr>	<td width="90px" ><span id="vP1">?</span></td>	<td width="90px" ><span id="vP2">?</span></td>	<td width="90px" ><span id="vP3">?</span></td>	<td width="90px" ><span id="vP4">?</span></td>	<td width="90px" ><span id="vP5">?</span></td>	<td width="90px" ><span id="vP6">?</span></td>	<td width="90px" ><span id="vP7">?</span></td>	<td width="90px" ><span id="vP8">?</span></td>	<td width="90px" ><span id="vP9">?</span></td>	<td width="90px" ><span id="vP0">?</span></td>	</tr></table>	</div>	<div style="position:absolute; width:1000px; bottom:0px; top:50px;" id="map"></div>
	<div style="position:absolute; top:0px; left:1008px; right:0px; bottom:0px; background: #bfbfbf; padding:10px; overflow-y: scroll;" id="brief">
	<img src="/images/areal.logo.png" border="0"; width="250px"; height="50px";  align="right" />
	
	<h2>Главный экран</h2>
	<h3>Строения</h3>
	<ul>
	<li>1.1 Резервуар чистой воды №1</li>
	<li>1.2 Резервуар чистой воды №2</li>
	<li>1.3 Резервуар чистой воды №3</li>
	<li>1.4 Резервуар чистой воды №4</li>
	<li>2 КПП</li>
	<li><a href="level2.3.html">3. Насосная станция првого подъема</a></li>
	<li><a href="level2.4.html">4. Насосная станция второго подъема</a></li>
	<li>5 Котельная</li>
	<li>6 Дизельгенераторная</li>
	<li>7 Накопительная емкость канализации</li>
	<li><a href="level2.8.html">8. Блок водоподготовки</a></li>
	<li><a href="level2.9.html">9. Блок обработки промывной воды</a></li>
	<li>10 Накопительная емкость канализации</li>
	<li>11 Склад реагентов</li>
	<li>12 Резерв промывной воды</li>
	<li>13 Хранилище пропан-бутана</li>
	
	
	</ul>
	
	
	
	
	</div>
<script type='text/javascript'>

	var imgW=973;
	var imgH=669;

	var imageUrl = './images/l1.png', imageBounds = [[-imgH/20, -imgW/20], [imgH/20, imgW/20]];
	
	var map = L.map('map', { minZoom: 3, maxZoom: 6,attributionControl:false});  
    map.attributionControl = false;
    L.imageOverlay(imageUrl, imageBounds, { opacity: 1 }).addTo(map); 
	map.setView([0, 5], 4);

	map.setMaxBounds([[-imgH/15, -imgW/15], [imgH/15, imgW/15]])
	
	
	
	L.easyButton({
	  id: 'id-map-print',  // an id for the generated button
	  position: 'topleft',      // inherited from L.Control -- the corner it goes in
	  type: 'replace',          // set to animate when you're comfy with css
	  leafletClasses: true,     // use leaflet classes to style the button?
	  states:[{                 // specify different icons and responses for your button
		stateName: 'map-print',
		onClick: function(button, map){
			$('#map').print();
		},
		title: 'Печать',
		icon: '<img src="/images/print.png" width="18px;" height="18px">'
	  }]
	}).addTo( map );
	
	
	/*
	var  drawnItems = L.featureGroup().addTo(map);
	
	
    map.addControl(new L.Control.Draw({
        edit: {
            featureGroup: drawnItems,
            poly: {
                allowIntersection: false
            }
        },
        draw: {
            polygon: {
                allowIntersection: false,
                showArea: true
            }
        }
    }));
	*/
	
	

	var rgb = '#00FF00'; // green
	var bounds;
    map.on(L.Draw.Event.CREATED, function (event) {
        var layer = event.layer;
        var s ="";
		if(typeof layer.toPolygon =='undefined'){
			s= JSON.stringify(layer.toGeoJSON()) ;
			drawnItems.addLayer(layer);
		}else{
			
			//alert ( JSON.stringify(layer.toPolygon(24,map)) );
			bounds=layer.toPolygon(24,map);
			var player= L.polygon( bounds, {  color: rgb, opacity: 1.0, fillOpacity: 1, weight: 1 } );
			s= JSON.stringify(player.toGeoJSON());
			drawnItems.addLayer(player);
		}
		
		$.ajax({
		  type: 'GET',
		  url: 'savelayer.aspx',
		  data: 'P=l1&L=' +s,
		  success: function(data){
			//$('.results').html(data);
		  }
		});
		
    });
	
	map.on('contextmenu',function(event){ }); 
	
	
	
	
	
	
	map.on('contextmenu',function(event){ }); 
 var stanki =[];
	var blink=true;
	  
	    function MapX(X) {
            var mx = parseInt(X);
            mx = mx / 10 -imgW/20;
            return mx;
        }

        function MapY(Y) {
            var my = parseInt(Y);
            my =  imgH/20 - my / 10;
            return my;
        }
	
	var rect;
	var bounds;
	var rgb = '#00FF00'; // green
	var marker;

	

	bounds=FlipLL([[-8.677652072909613,23.819618311015745,0],[-9.024289715149061,23.676036298371134,0],[-9.321954206745518,23.447630300606136,0],[-9.550360204510516,23.14996580900968,0],[-9.69394221715513,22.80332816677023,0],[-9.742915367798119,22.43134015636062,0],[-9.69394221715513,22.05935214595101,0],[-9.550360204510516,21.71271450371156,0],[-9.321954206745518,21.415050012115103,0],[-9.024289715149061,21.186644014350104,0],[-8.677652072909613,21.043062001705493,0],[-8.305664062500002,20.9940888510625,0],[-7.933676052090391,21.043062001705493,0],[-7.587038409850942,21.186644014350104,0],[-7.289373918254485,21.415050012115103,0],[-7.060967920489487,21.71271450371156,0],[-6.917385907844875,22.05935214595101,0],[-6.868412757201884,22.43134015636062,0],[-6.917385907844874,22.80332816677023,0],[-7.060967920489487,23.14996580900968,0],[-7.289373918254484,23.447630300606136,0],[-7.5870384098509405,23.676036298371134,0],[-7.933676052090389,23.819618311015745,0],[-8.677652072909613,23.819618311015745,0]]);
	rect = L.polygon(bounds, {  color: rgb, opacity: 1.0, fillOpacity: 0.5, weight: 2 });
	rect.tag = '3';
	//rect.bindPopup('Насосная станция првого подъема');
	rect.bindTooltip('Насосная станция првого подъема')
	rect.on('contextmenu',function(event){ window.location="level2.3.html";});
	rect.on('dblclick',function(event){ window.location="level2.3.html";});
	rect.on('contextmenu',function(event){ }); 
    rect.blink = blink;
	stanki.push(rect);
	rect.addTo(map);
	
	
	
	bounds=FlipLL([[-16.347656250000004,14.43468021529728],[-16.303710937500004,16.46769474828897],[-2.7685546875000004,16.551961721972525],[-2.7685546875000004,13.068776734357694],[-14.765625000000002,12.940322128384627],[-14.677734375000002,14.604847155053898],[-16.347656250000004,14.43468021529728]]);
	rect = L.polygon(bounds, { color: rgb, opacity: 1.0, fillOpacity: 0.5, weight: 2 });
	rect.tag = '4';
	//rect.bindPopup('Насосная станция второго подъема');
	rect.bindTooltip('Насосная станция второго подъема')
	rect.on('contextmenu',function(event){ window.location="level2.4.html";});
	rect.on('dblclick',function(event){ window.location="level2.4.html";});
	rect.blink = true;
	stanki.push(rect);
	rect.addTo(map);
	
	
	
	bounds=FlipLL([[-25.576171875,0.4833927027896987],[-13.139648437500002,0.4833927027896987],[-13.095703125,-4.565473550710278],[-25.620117187500004,-4.609278084409823],[-25.576171875,0.4833927027896987]]);
	rect = L.polygon(bounds, { color: rgb, opacity: 1.0, fillOpacity: 0.5, weight: 2 });
	rect.tag = '8';
	//rect.bindPopup('Блок водоподготовки');
	rect.bindTooltip('Блок водоподготовки')
	rect.on('contextmenu',function(event){ window.location="level2.8.html";});
	rect.on('dblclick',function(event){ window.location="level2.8.html";});
	rect.on('contextmenu',function(event){ }); 
 rect.blink = blink;
	stanki.push(rect);
	//marker = new L.Marker.Text([MapY(280), MapX(200)], '8', { opacity: 0.75 } ).bindPopup('Блок водоподготовки').addTo(map);
	rect.marker=marker;
	rect.addTo(map);

	
	bounds=FlipLL([[-25.664062500000004,-10.09867012060338],[-13.0078125,-10.09867012060338],[-12.919921875000002,-15.114552871944102],[-25.620117187500004,-15.156973713377667],[-25.664062500000004,-10.09867012060338]]);
	rect = L.polygon(bounds, { color: rgb, opacity: 1.0, fillOpacity: 0.5, weight: 2 });
	rect.tag = '9';
	//rect.bindPopup('Блок обработки промывной воды');
	rect.bindTooltip("Блок обработки промывной воды")
	rect.on('contextmenu',function(event){ window.location="level2.9.html";});
	rect.on('dblclick',function(event){ window.location="level2.9.html";});
	rect.blink = true;
	//rect.on('contextmenu',function(event){ }); 
 rect.blink = blink;
	stanki.push(rect);
	rect.addTo(map);
	



	function FlipLL(b) {
		var fb;
		var point;
		var j;
		fb=[];
		for (j = 0; j < b.length; j++) {
			 point =new  L.latLng(
			  b[j][1],               
			  b[j][0],               
               b[j][2]             
            );
			fb.push(point)
		}
		return fb;
	}

    function ReloadData() {

            function OnRequestReady(data) {

                $.each(data.data, function (i, v) {
                    var ok = false;
                    var rect;
                    var j;
                    for (j = 0; j < stanki.length; j++) {
                        if (stanki[j].tag == v.ID) {
                            ok = true;
                            rect = stanki[j];
                            break;
                        }
                    }

                    if (ok) {
						if(v.BLINK=='YES'){
							blink=true;
						}else{
							blink=false;
						}
					
						switch (v.COLOR) {
							case 'GREEN':
								 rgb = '#00FF00'; // green
								break;
							case 'YELLOW':
								rgb = '#dddd00';
								break;
							case 'RED':
								 rgb = '#FF0000'; //red
								break;
							default:
								rgb = '#000000'; //black
								break;
						}
                        rect.setStyle({ color: rgb, opacity: 1.0, fillOpacity: 0.5, weight: 1 });
                       // //rect.bindPopup(sPopup);
                       // rect.marker.bindPopup(sPopup);
                        rect.on('contextmenu',function(event){ }); 
						rect.blink = blink;
					}
					if(v.INFO !=null){
						var item=document.getElementById('v' +v.ID);
						if( item!=null){
							item.innerHTML =v.INFO;
						}else{
							console.log(v.ID);
						}
					}
                    
                });


            };
           $.ajax({
                dataType: "json",
                url: 'l1.aspx',
                success: OnRequestReady
            });
        }
        var blinkMode = false;
        function Blinker() {
            blinkMode = !blinkMode;
            var j;
            for (j = 0; j < stanki.length; j++) {

                rect = stanki[j];
                if (rect.blink == true) {
                    if (blinkMode) {
                        rect.setStyle({  fillOpacity: 0.1 });
                    } else {
                        rect.setStyle({  fillOpacity: 0.5 });
                    }
                }
               
            }
           

        }

        ReloadData();

		var intervalID = window.setInterval(ReloadData, 1000);   

		var intervalID2 = window.setInterval(Blinker, 500);   
   

</script>
 
</body>
</html>
