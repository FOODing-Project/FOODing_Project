<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>

<link rel = "stylesheet" href = "${pageContext.request.contextPath}/resources/css/main_style_header.css" type = "text/css">
<link href = "https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
<link rel = "stylesheet" href = "${pageContext.request.contextPath}/resources/css/main_style_nav.css" type = "text/css">
<link rel = "stylesheet" href = "${pageContext.request.contextPath}/resources/css/main_style_footer.css" type = "text/css">
<script src = "https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src = "${pageContext.request.contextPath}/resources/js/nav_hover.js"></script>

<header>
    <div class = "header-div">
        <div class = "hello1"></div>
        <a class = "header1" href = "main">FOOD</a>
        <a class = "header2" href = "main">ing</a>
        <a class = "header2" href = "main">
            <img src = "${pageContext.request.contextPath}/resources/images/chefudding.png" width = "100px" height = "100px">
        </a>
        <div class = "hello2">
            <table border = "0" align = "center">
                <tr>
                    <td align = "center">
                        <c:if test="${sessionScope.loggedInMember != null}">
                            ${sessionScope.loggedInMember.mname}님, 안녕하세요!
                        </c:if>
                        <c:if test="${sessionScope.loggedInMember == null}">
                            어서오세요!
                        </c:if>
                    </td>
                </tr>
                <tr>
                    <td align = "center">
                        <span>
                            종
                        </span>
                        <span>|</span>
                        <span>
                            <c:if test="${sessionScope.loggedInMember != null}">
                               <a href="<%= request.getContextPath() %>/member/view?mid=${sessionScope.loggedInMember.mid}">개인정보</a>
                            </c:if>
                            <c:if test="${sessionScope.loggedInMember == null}">
                                <a class = "head" href = "registerSelect">회원가입</a>
                            </c:if>
                        </span>
                        <span>|</span>
                        <span>
                            <c:if test="${sessionScope.loggedInMember != null}">
                               <a href="<%= request.getContextPath() %>/logout">로그아웃</a>
                            </c:if>
                            <c:if test="${sessionScope.loggedInMember == null}">
                                <a href="<%= request.getContextPath() %>/login">로그인</a>
                            </c:if>
                        </span>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</header>

