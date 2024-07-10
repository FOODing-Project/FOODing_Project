<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@ taglib uri="http://java.sun.com/jstl/core_rt" prefix="c"%>
<div class = "all-review-div">
<form:form method="post" action="${pageContext.request.contextPath}/review" modelAttribute="review" id="review">
    <form:hidden path="store.sno" value="${sno}"/>
    <div class="form-group">
        <div class="rating">
            <span data-value="1">☆</span>
            <span data-value="2">☆</span>
            <span data-value="3">☆</span>
            <span data-value="4">☆</span>
            <span data-value="5">☆</span>
        </div>
        <input type="hidden" name="rstar" id="rstar" value="0"/>
    </div>
    <div class="form-group">
        <form:textarea path="rcomm" id="rcomm" class="custom-textarea" placeholder="리뷰 내용을 입력하세요."></form:textarea>
    </div>
    <div class="form-group">
        <button type="submit">리뷰 작성</button>
    </div>
</form:form>


<h2>리뷰 목록</h2>


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


