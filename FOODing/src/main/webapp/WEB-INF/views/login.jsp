<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri = "http://java.sun.com/jstl/core_rt" prefix = "c"%>

<%@ taglib uri = "http://java.sun.com/jstl/core_rt" prefix = "c"%>
<!DOCTYPE html>
<html>
<head>
    <meta charset = "UTF-8">
    <title>FOODing 메인화면</title>
    <link rel="stylesheet" href="${pageContext.request.contextPath}/resources/css/login.css">
    <script src="${pageContext.request.contextPath}/resources/js/validation.js"></script>

</head>
<body>
<c:import url = "/topNoneNav.jsp" />
<div class="login-container">
<div class="form-container">
    <h1>로그인</h1>

    <%-- 에러 메시지가 있을 경우에만 표시 --%>
    <c:if test="${not empty error}">
        <p class="error-message">${error}</p>
    </c:if>
    <!-- 첫 번째 폼 -->
    <form id="first-form" onsubmit="return saveIdAndShowSecondForm()">
        <div>
            <label for="mid">ID</label>
            <input type="text" id="mid" name="id" required >
        </div>
        <div>
            <input class="button" type="submit" value="다음">
        </div>
        <div class="helper-links">
            <a href="${pageContext.request.contextPath}/find-id">회원ID 찾기</a>
            <a href="${pageContext.request.contextPath}/find-pass">비밀번호 찾기</a>
        </div>
    </form>

    <!-- 두 번째 폼 -->
    <form id="second-form" action="${pageContext.request.contextPath}/login" method="post" class="form-step">
        <input type="hidden" id="idHidden" name="id">
        <div>
            <label for="mpass">비밀번호</label>
            <input type="password" id="mpass" name="password" required>
        </div>
        <div>
            <input class="button" type="submit" value="로그인" onclick="submitSecondForm()">
        </div>
        <div class="helper-links">
            <a href="${pageContext.request.contextPath}/find-pass">비밀번호 찾기</a>
        </div>
    </form>
</div>
</div>

<c:import url = "/bottom.jsp" />



