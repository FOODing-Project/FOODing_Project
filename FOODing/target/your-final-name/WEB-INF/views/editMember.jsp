<%@ page contentType="text/html;charset=UTF-8" language="java" pageEncoding="UTF-8" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>

<%@ taglib uri = "http://java.sun.com/jstl/core_rt" prefix = "c"%>
<c:import url = "/top.jsp" />

<!DOCTYPE html>
<html>
<head>
    <title>회원 정보 수정</title>
    <link rel="stylesheet" href="${pageContext.request.contextPath}/resources/css/editMember.css">
    <script src="${pageContext.request.contextPath}/resources/js/validation.js"></script>
</head>
<body>
<h1>회원 정보 수정</h1>
<form:form action="${pageContext.request.contextPath}/member/edit" modelAttribute="member" method="post">
    <table border="1" align="center">
        <tr>
            <td><form:label path="mname">성명</form:label></td>
            <td><form:input path="mname" /></td>
        </tr>
        <tr>
            <td><form:label path="mpass">비밀번호</form:label></td>
            <td><form:input path="mpass" type="password" /></td>
        </tr>
        <tr>
            <td><form:label path="mpassConfirm">비밀번호 확인</form:label></td>
            <td>
                <form:input path="mpassConfirm" id="mpassConfirm" name="mpassConfirm" type="password" />
                <button type="button" onclick="validatePassword()">비밀번호 확인</button>
                <span id="confirmMessage" class="error"></span><br/>
                <form:errors path="mpassConfirm" cssClass="error" />
            </td>
        </tr>
        <tr>
            <td><form:label path="mnick">닉네임</form:label></td>
            <td><form:input path="mnick" /></td>
        </tr>
        <tr>
            <td><form:label path="mbirth">생년월일</form:label></td>
            <td><form:input path="mbirth" /></td>
        </tr>
        <tr>
            <td><form:label path="mphone">전화번호</form:label></td>
            <td><form:input path="mphone" /></td>
        </tr>
        <tr>
            <td><form:label path="memail">이메일</form:label></td>
            <td><form:input path="memail" /></td>
        </tr>
        <tr>
            <td><form:label path="maddr">주소</form:label></td>
            <td><form:input path="maddr" /></td>
        </tr>
        <tr>
            <td colspan="2" align="center"><input type="submit" value="수정" /></td>
        </tr>
    </table>
    <form:hidden path="mid" />
</form:form>

<c:import url = "/bottom.jsp" />
</body>
</html>