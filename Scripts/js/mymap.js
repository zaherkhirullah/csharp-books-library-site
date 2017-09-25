/*
 * Merope
 * Google Map for Merope HTML5 Template
 * Copyright 2016, Filip Greksa
 * www.filipgreksa.com
 * 2016/06/23
 */

/*global google, alert*/
var map;

function initMap() {
	"use strict";
	
	// Set address here
	var	address = '795 Folsom Ave, San Francisco, CA 94103',
		
		paper = [
			{"featureType": "all", "elementType": "all", "stylers": [{"saturation": -100}, {"gamma": 0.5}]}, {"featureType": "water", "elementType": "all", "stylers": [{"visibility": "on"}, {"color": "#bbdefb"}]}
		],
		
		map = new google.maps.Map(document.getElementById('mymap'), {
			zoom: 14,
			styles: paper,
			scrollwheel: false,
			mapTypeId: google.maps.MapTypeId.ROADMAP //another options SATELLITE, HYBRID, TERRAIN
		}),
		
		//Geocoder - change lat, lng to address
		geocoder = new google.maps.Geocoder();
	geocoder.geocode({
		'address': address
	}, function (results, status) {
		if (status === google.maps.GeocoderStatus.OK) {
			map.setCenter(results[0].geometry.location);
			//Marker
			var marker = new google.maps.Marker({
				position: results[0].geometry.location,
				map: map,
				icon: "img/Arrow_1.png",
				title: 'Hello World!'
			}),
				infowindow = new google.maps.InfoWindow({
					content: "aaaa",
					maxWidth: 200
				});
			marker.addListener('click', function () {
				infowindow.open(map, marker);
			});
		} else {
			alert('Geocode was not successful for the following reason: ' + status);
		}
	});
}

initMap();