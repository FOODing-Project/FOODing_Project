<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@ taglib uri="http://java.sun.com/jstl/core_rt" prefix="c"%>
<!DOCTYPE html>
<html>
<head>
    <link rel="stylesheet" type="text/css" href="${pageContext.request.contextPath}/resources/css/review.css">
    <title>리뷰 목록 보기</title>
</head>
<body>
<c:import url="/top.jsp" />

<section class="section-reviews">
    <div><h2>리뷰 작성</h2></div>

    <div>
        <form:form method="post" action="${pageContext.request.contextPath}/review" modelAttribute="review">
            <form:hidden path="store.sno" value="${sno}" />
            <div class="form-group">
                <label for="rstar">별점:</label>
                <form:select path="rstar" id="rstar">
                    <form:option value="1">1</form:option>
                    <form:option value="2">2</form:option>
                    <form:option value="3">3</form:option>
                    <form:option value="4">4</form:option>
                    <form:option value="5">5</form:option>
                </form:select>
            </div>
            <div class="form-group">
                <label for="rcomm">리뷰 내용:</label>
                <form:textarea path="rcomm" id="rcomm" rows="4" cols="50"></form:textarea>
            </div>
            <div class="form-group">
                <button type="submit">리뷰 작성</button>
            </div>
        </form:form>
    </div>

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

<c:import url="/bottom.jsp" />
</body>
</html>

