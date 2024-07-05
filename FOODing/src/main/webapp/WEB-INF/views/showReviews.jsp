<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html>
<html>
<head>
    <title>리뷰 목록 보기</title>
    <style>
        .review-container {
            border: 1px solid black;
            padding: 10px;
            margin: 10px;
        }
        .review-item {
            margin-bottom: 5px;
        }
    </style>
</head>
<body>
<h2>리뷰 목록</h2>
<c:forEach var="review" items="${reviews}">
    <div class="review-container">
        <div class="review-item">작성 날짜: ${review.rdate}</div>
        <div class="review-item">별점:
            <c:forEach begin="1" end="${review.rstar}" var="i">★</c:forEach>
            <c:forEach begin="${review.rstar + 1}" end="5" var="i">☆</c:forEach>
        </div>
        <div class="review-item">리뷰 내용:</div>
        <div class="review-item" style="border: 1px solid black; padding: 10px;">${review.rcomm}</div>
    </div>
</c:forEach>
</body>
</html>