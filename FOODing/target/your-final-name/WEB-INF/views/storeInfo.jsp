<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<div id="store-info">
    <div class="store-info">
        <h2 class="menu-title">메뉴</h2>
        <table class="menu-table">
            <thead>
            <tr>
                <td>메뉴이름</td>
                <td>가격</td>
            </tr>
            </thead>
            <tbody>
            <c:forEach var="menu" items="${menus}">
                <tr>
                    <td>${menu.mnname}</td>
                    <td>${menu.mnprice}</td>
                </tr>
            </c:forEach>
            </tbody>
        </table>
        <h2>영업시간</h2>
        <p>${store.stime}</p>
        <h2>주차</h2>
        <p>${store.spark}</p>
        <h2>전화번호</h2>
        <p>${store.stel}</p>
    </div>
    <div id="map-container">
        <p id="store-address">${store.saddr}</p>
        <div id="map" style="width:100%;height:400px;"></div>
    </div>
</div>

<script>
    function initializeMap() {
        var mapContainer = document.getElementById('map'),
            mapOption = {
                center: new kakao.maps.LatLng(33.450701, 126.570667),
                level: 3
            };

        var map = new kakao.maps.Map(mapContainer, mapOption);
        var geocoder = new kakao.maps.services.Geocoder();

        geocoder.addressSearch("${store.saddr}", function(result, status) {
            if (status === kakao.maps.services.Status.OK) {
                var coords = new kakao.maps.LatLng(result[0].y, result[0].x);
                var marker = new kakao.maps.Marker({
                    map: map,
                    position: coords
                });

                var infowindow = new kakao.maps.InfoWindow({
                    content: '<div style="width:150px;text-align:center;padding:6px 0;">우리회사</div>'
                });
                infowindow.open(map, marker);
                map.setCenter(coords);
            }
        });

        // store-info 높이에 맞춰 map-container 및 map 높이 조정
        function adjustMapHeight() {
            var storeInfo = document.querySelector('.store-info');
            var mapContainer = document.getElementById('map-container');
            var map = document.getElementById('map');
            var storeAddress = document.getElementById('store-address');
            if (storeInfo && mapContainer && map && storeAddress) {
                var storeInfoHeight = storeInfo.offsetHeight;
                var storeAddressHeight = storeAddress.offsetHeight;
                mapContainer.style.height = storeInfoHeight + 'px';
                map.style.height = (storeInfoHeight - storeAddressHeight - 10) + 'px';
            }
        }

        // 처음 로드할 때 지도 높이 조정
        adjustMapHeight();

        // 창 크기 변경 시 지도 높이 재조정
        window.addEventListener('resize', adjustMapHeight);
    }

    document.addEventListener("DOMContentLoaded", function() {
        loadKakaoMapScript(initializeMap);
    });
</script>
