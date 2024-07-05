<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@ taglib uri = "http://java.sun.com/jstl/core_rt" prefix = "c"%>

<c:import url = "/top.jsp" />

<section>
    <div class="store-container">
        <h2>임시 가게 목록</h2>

        <form:form action="store" modelAttribute="store" method="post">
            <h3>여기에 가게명 출력</h3>

            <h3>여기에 리뷰 버튼 출력</h3>
        </form:form>
    </div>
</section>

<c:import url = "/bottom.jsp" />