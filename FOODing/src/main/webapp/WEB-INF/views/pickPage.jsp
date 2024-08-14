<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@ taglib uri="http://java.sun.com/jstl/core_rt" prefix="c"%>
<link rel="stylesheet" type="text/css" href="${pageContext.request.contextPath}/resources/css/pick.css">
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<c:import url="/top.jsp" />
<div class="pick-container">
    <h2>찜 폴더 관리</h2>
    <div class="pickList-container">
        <c:forEach var="pick" items="${pickList}">
            <div class="pick-item">
                <h3>${pick.store.sname}</h3>
                <p>${pick.store.saddr}</p>
                <p>${pick.store.stel}</p>
                <%--<button class="remove-pick" data-pno="${pick.pno}">삭제</button>--%>
            </div>
        </c:forEach>
    </div>

</div>
<script>
    /*$(document).on('click', '.remove-pick', function() {
        var pno = $(this).data('pno');
        $.ajax({
            type: 'POST',
            url: '${pageContext.request.contextPath}/removePick',
            data: { pno: pno },
            success: function(response) {
                if (response === 'success') {
                    alert('찜 목록에서 삭제되었습니다.');
                    location.reload(); // 페이지를 새로고침하여 목록을 업데이트합니다.
                } else {
                    alert('삭제 중 오류가 발생했습니다.');
                }
            }
        });
    });*/
</script>
<c:import url="/bottom.jsp" />