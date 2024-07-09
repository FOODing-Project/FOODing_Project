<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>FOODing 가게 디테일</title>
    <link rel="stylesheet" type="text/css" href="${pageContext.request.contextPath}/resources/css/storeDetail.css">
    <link rel="stylesheet" type="text/css" href="${pageContext.request.contextPath}/resources/css/review.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="//dapi.kakao.com/v2/maps/sdk.js?appkey=573fb4487497eb28636a2f91b5ca8f70&libraries=services"></script> <!-- Kakao 지도 API -->
</head>
<body>
<!-- 상단 내비게이션 바 -->
<c:import url="/top.jsp" />

<section>
    <div class="store-div">
        <!-- 가게 정보 섹션 -->
        <c:choose>
            <c:when test="${store.scate == '한식'}">
                <img id="store-img" src="${pageContext.request.contextPath}/resources/store_images/korean_food.jpg">
            </c:when>
            <c:when test="${store.scate == '일식'}">
                <img id="store-img" src="${pageContext.request.contextPath}/resources/store_images/japanese_food.jpg">
            </c:when>
            <c:when test="${store.scate == '중식'}">
                <img id="store-img" src="${pageContext.request.contextPath}/resources/store_images/chinese_food.jpg">
            </c:when>
            <c:otherwise>
                <img id="store-img" src="${pageContext.request.contextPath}/resources/store_images/fastfood.jpg">
            </c:otherwise>
        </c:choose>
        <div class="store-head">
            <p id="store-title">${store.sname}</p>
            <p>${store.scate}</p>
            <p id="store-explain">${store.seg}</p>
        </div>

        <!-- 탭 바 -->
        <div class="tab-bar">
            <button id="store-info-tab" class="tab active">가게 정보</button>
            <button id="reviews-tab" class="tab">리뷰</button>
        </div>

        <!-- 가게 정보 및 리뷰 섹션 -->
        <div id="content-container" class="store-info-map">
            <c:import url="/WEB-INF/views/storeInfo.jsp" />
        </div>
    </div>
</section>

<!-- 하단 내비게이션 바 -->
<c:import url="/bottom.jsp" />
<script>
    document.addEventListener("DOMContentLoaded", function() {
        // 탭 클릭 이벤트 핸들러
        $('#store-info-tab').click(function() {
            console.log('가게 정보 탭 클릭');
            loadContent('${pageContext.request.contextPath}/storeInfo.jsp');
            $('.tab').removeClass('active');
            $(this).addClass('active');
        });

        $('#reviews-tab').click(function() {
            console.log('리뷰 탭 클릭');
            loadContent('${pageContext.request.contextPath}/review?sno=${store.sno}');
            $('.tab').removeClass('active');
            $(this).addClass('active');
        });

        function loadContent(url) {
            console.log('Loading content from:', url);
            $('#content-container').load(url, function(response, status, xhr) {
                if (status === 'error') {
                    console.log("Error loading content: " + xhr.status + " " + xhr.statusText);
                } else {
                    console.log('Content loaded successfully from:', url);
                }
            });
        }
    });
</script>
</body>
</html>