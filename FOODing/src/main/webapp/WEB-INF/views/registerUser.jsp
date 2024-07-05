<%@ page contentType="text/html;charset=UTF-8" language="java" pageEncoding="UTF-8" %>

<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>

<%@ taglib uri = "http://java.sun.com/jstl/core_rt" prefix = "c"%>
<c:import url = "/top.jsp" />


    <link rel="stylesheet" href="${pageContext.request.contextPath}/resources/css/register.css">
    <script src="${pageContext.request.contextPath}/resources/js/validation.js"></script>

<section>
<h2>${memberType} 회원등록</h2>
<form:form name="registrationForm" action="${pageContext.request.contextPath}/register/user" modelAttribute="member" method="post" onsubmit="return validateForm()">
    <table border="1" align="center">
        <tr>
            <td><form:label path="mid">ID</form:label></td>
            <td><form:input path="mid" />
                <form:errors path="mid" cssClass="error" />
            </td>
        </tr>
        <tr>
            <td><form:label path="mname">성명</form:label></td>
            <td><form:input path="mname" />
                <form:errors path="mname" cssClass="error" />
            </td>
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
                <span id="confirmMessage" class="error"></span>
                <form:errors path="mpassConfirm" cssClass="error" />
            </td>
        </tr>
        <tr>
            <td><p>회원 유형</p></td>
            <td>${memberType}</td>
        </tr>
        <tr>
            <td><form:label path="mnick">닉네임</form:label></td>
            <td><form:input path="mnick" />
                <form:errors path="mnick" cssClass="error" />
            </td>
        </tr>
        <tr>
            <td><form:label path="mbirth">생년월일</form:label></td>
            <td><form:input path="mbirth" />
                <form:errors path="mbirth" cssClass="error" />
            </td>
        </tr>
        <tr>
            <td><form:label path="mphone">전화번호</form:label></td>
            <td><form:input path="mphone" />
                <form:errors path="mphone" cssClass="error" />
            </td>
        </tr>
        <tr>
            <td><form:label path="memail">이메일</form:label></td>
            <td><form:input path="memail" />
                <form:errors path="memail" cssClass="error" />
            </td>
        </tr>
        <tr>
            <td><form:label path="maddr">주소</form:label></td>
            <td><form:input path="maddr" />
                <form:errors path="maddr" cssClass="error" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center"><input type="submit" value="등록" /></td>
        </tr>
    </table>
    <form:hidden path="mtype" />
</form:form>
</section>
<c:import url = "/bottom.jsp" />
