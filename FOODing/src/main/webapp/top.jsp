<%@ page contentType="text/html;charset=UTF-8" language="java" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset = "UTF-8">
        <title>FOODing 메인화면</title>
    </head>
    <body>
        <header>
            <link rel = "stylesheet" href = "resources/css/style_header.css" type = "text/css">
            <div class = "header-div">
                <a class = "header1" href = "main">FOOD</a>
                <a class = "header2" href = "main">ing</a>
                <a class = "header2" href = "main">
                    <img src = "${pageContext.request.contextPath}/resources/images/chefudding.png" width = "100px" height = "100px">
                </a>
            </div>
        </header>
        <nav>
            <link rel = "stylesheet" href = "resources/css/style_nav.css" type = "text/css">
            <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
            <script src="resources/js/nav_hover.js"></script>
            <div class = "nav-div">
                <a class = "nav" href = "#">음식점 카테고리</a>
                <a class = "nav" href = "#">가게리스트</a>
                <a class = "nav" href = "#">모임</a>
                <a class = "nav" href = "#">찜</a>
                <a class = "nav" href = "#">검색</a>
                <ul class = "snb">
                    <div class = "submenu">
                        <li><a href = "#">한식</a></li>
                        <li><a href = "#">중식</a></li>
                        <li><a href = "#">일식</a></li>
                    </div>
                    <div class="submenu">
                        <li><a href="#">위치별</a></li>
                        <li><a href="#">순위별</a></li>
                        <li><a href="#">태그별</a></li>
                    </div>
                    <div class = "submenu">
                        <li><a href = "#">모임 기능1</a></li>
                        <li><a href = "#">모임 기능2</a></li>
                        <li><a href = "#">모임 기능3</a></li>
                    </div>
                    <div class = "submenu">
                        <li><a href = "#">찜 기능1</a></li>
                        <li><a href = "#">찜 기능2</a></li>
                        <li><a href = "#">찜 기능3</a></li>
                    </div>
                    <div class = "submenu">
                        <li><a href = "#">검색 기능1</a></li>
                        <li><a href = "#">검색 기능2</a></li>
                        <li><a href = "#">검색 기능3</a></li>
                    </div>
                </ul>
            </div>
        </nav>
