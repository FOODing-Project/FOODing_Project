<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@ taglib uri = "http://java.sun.com/jstl/core_rt" prefix = "c"%>

<c:import url = "/top.jsp" />

<head>
    <link rel="stylesheet" type="text/css" href="${pageContext.request.contextPath}/resources/css/review.css">
    <title>리뷰 목록 보기</title>
</head>
<section class="section-reviews">
    <div><h2>리뷰 목록</h2></div>

    <div>
    <c:forEach var="review" items="${reviews}">
        <div class="review-container">
            <div class="review-item review-item-left"><strong>닉네임 여기다 표시</strong></div>
            <div class="review-item review-item-right"><strong>작성 날짜 : </strong> ${review.rdate}</div>
            <div class="review-item review-item-left" style="top: 30px;"><strong>별점 : </strong>
                <span class="star-rating">
                <c:forEach begin="1" end="${review.rstar}" var="i">★</c:forEach>
                <c:forEach begin="${review.rstar + 1}" end="5" var="i">☆</c:forEach>
                </span>
            </div>
            <div class="review-item-content">
                <div class="review-item"><strong>리뷰 내용 : </strong></div>
                <div class="review-item review-content">${review.rcomm}</div>
            </div>
        </div>
    </c:forEach>
    </div>
</section>
