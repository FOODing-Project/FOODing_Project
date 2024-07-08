<%@ page contentType="text/html;charset=UTF-8" language="java" pageEncoding="UTF-8" %>

<%@ taglib uri = "http://java.sun.com/jstl/core_rt" prefix = "c"%>

<!DOCTYPE html>
<html>
<head>
    <title>회원가입 선택</title>
    <link rel="stylesheet" href="${pageContext.request.contextPath}/resources/css/registerSelect.css">

</head>
<body>
<c:import url = "/top.jsp" />
<div class="button-container">
<h2>회원가입을 선택해주세요</h2>
    <a href="${pageContext.request.contextPath}/register/user" class="btn-user">일반 회원가입</a>
    <a href="${pageContext.request.contextPath}/register/owner" class="btn-owner">사장님 회원가입</a>
</div>

<c:import url = "/bottom.jsp" />
</body>
</html>
