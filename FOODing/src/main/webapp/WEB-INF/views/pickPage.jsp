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
        <div class="removeButton-container">
            <button type="submit" id="deletePick" class="deletePick">삭제</button>
        </div>
    </div>
    <div class="addToFolder-container">
        <button type="button" class="add-button"><img src="${pageContext.request.contextPath}/resources/images/addToFolder.png"></button>
    </div>
    <div class="pickFolders-container">
        <h4>찜 폴더 관리</h4>
        <div class="addFolder-container">
            <form method="post" action="${pageContext.request.contextPath}/createFolder">
                <input type="hidden" name="pfname" value="새 폴더" />
                <button type="submit" class="createFolder">+새 폴더</button>
            </form>
        </div>
        <form id="deleteFolderForm" method="post" action="${pageContext.request.contextPath}/deleteFolder">
            <table class="folder-table">
                <c:forEach var="pfolder" items="${pfolderList}">
                    <tr>
                        <td>
                            <div class="folder-items">
                            <div class="folder-items folder-items-left">
                                <input type="checkbox" name="selectedFolders" value="${pfolder.pfno}" class="folder-checkbox"/>
                                <label>${pfolder.pfname}</label>
                            </div>
                            <div class="folder-items folder-items-right">
                                <button type="button" class="edit-button">
                                    <img src="${pageContext.request.contextPath}/resources/images/edit_icon.png">
                                </button>
                            </div>
                            </div>
                        </td>
                    </tr>
                </c:forEach>
            </table>
            <div class="removeButton-container">
                <button type="submit" id="deleteFolder" class="deleteFolder">삭제</button>
            </div>
        </form>
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
    document.getElementById("deleteFolder").addEventListener("click", function() {
        var checkboxes = document.querySelectorAll(".folder-checkbox:checked");
        if (checkboxes.length === 0) {
            alert("삭제할 폴더를 선택하세요.");
        } else {
            checkboxes.forEach(function(checkbox) {
            });
            document.getElementById("deleteFolderForm").submit(); // 폼 제출
        }
    });
</script>
<c:import url="/bottom.jsp" />