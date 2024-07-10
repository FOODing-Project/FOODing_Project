<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@ taglib uri = "http://java.sun.com/jstl/core_rt" prefix = "c"%>

<!DOCTYPE html>
<html>
<head>
    <meta charset = "UTF-8">
    <title>FOODing 메인화면</title>
</head>
<body>
<c:import url = "/top.jsp" />

<section>
    <div class="store-container">
        <h2>임시 가게 목록</h2>
        <c:forEach var="store" items="${stores}">
            <div class="store-item">
                <a href="${pageContext.request.contextPath}/review?sno=${store.sno}">${store.sname}</a>
            </div>
        </c:forEach>
    </div>
</section>

<c:import url = "/bottom.jsp" />