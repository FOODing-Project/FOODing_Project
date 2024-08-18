<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@ taglib uri="http://java.sun.com/jstl/core_rt" prefix="c"%>
<link rel="stylesheet" type="text/css" href="${pageContext.request.contextPath}/resources/css/pick.css">
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<c:import url="/top.jsp" />
<h2>찜 폴더 관리</h2>
<div class="pick-container">
    <div class="pickList-container">
        <h4>전체 찜 목록</h4>
            <table class="pick-table">
                <c:forEach var="pick" items="${pickList}">
                <tr>
                    <td>
                        <input type="checkbox" name="selectedStore" value="${pick.store.sname}" />
                        <button class="storeName">${pick.store.sname}</button>
                    </td>
                </tr>
                </c:forEach>
            </table>
        <div class="pickList-button-container">
            <button class="delete-pick">-삭제</button>
        </div>
    </div>
    <div class="pickFolders-container">
        <h4>찜 폴더 관리</h4>
            <table class="folder-table">
                <c:forEach var="pfolder" items="${pfolderList}">
                    <tr>
                        <td>
                            <input type="checkbox" name="selectedFolders" value="${pfolder.pfno}" class="folder-checkbox"/>
                            <button class="folderName">${pfolder.pfname}</button>
                        </td>
                    </tr>
                </c:forEach>
            </table>
        <div class="pickFolders-button-container">
            <form method="post" action="${pageContext.request.contextPath}/createFolder">
                <input type="hidden" name="pfname" value="새 폴더" />
                <button type="submit">+새 폴더</button>
            </form>
            <form id="deleteFolderForm" method="post" action="${pageContext.request.contextPath}/deleteFolder">
                <button type="button" id="deleteButton">삭제</button>
            </form>
        </div>
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
<script>
    document.getElementById("deleteButton").addEventListener("click", function() {
        var checkboxes = document.querySelectorAll(".folder-checkbox:checked");
        if (checkboxes.length === 0) {
            alert("삭제할 폴더를 선택하세요");
        } else {
            document.getElementById("deleteFolderForm").submit(); // 폼 제출
        }
    });
</script>
<c:import url="/bottom.jsp" />