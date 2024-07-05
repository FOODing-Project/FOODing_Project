<%--
  Created by IntelliJ IDEA.
  User: User
  Date: 2024-07-02
  Time: 오후 2:22
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@ taglib uri = "http://java.sun.com/jstl/core_rt" prefix = "c"%>

<c:import url = "/top.jsp" />

<section>
    <div class="review-container">
    <h2>리뷰 작성하기</h2>

    <form:form action="review" modelAttribute="review" method="post">
        <h3>여기에 가게명 출력</h3>
        <form:label path="rstar">별점을 선택해주세요   </form:label>
        <form:select path="rstar">
            <form:option value="5" label="5"/>
            <form:option value="4" label="4"/>
            <form:option value="3" label="3"/>
            <form:option value="2" label="2"/>
            <form:option value="1" label="1"/>
        </form:select><br/><br/>

        <form:label path="rcomm">리뷰를 작성해주세요</form:label><br/>
        <form:textarea path="rcomm" cssClass="large-textarea" placeholder="내용을 입력하세요."></form:textarea><br/><br

        <h3>여기에 태그 입력</h3>

        <input type="submit" value="등록"/>
    </form:form>
    </div>
</section>

<c:import url = "/bottom.jsp" />