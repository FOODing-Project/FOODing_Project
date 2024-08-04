<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@ taglib uri="http://java.sun.com/jstl/core_rt" prefix="c"%>
<link rel="stylesheet" type="text/css" href="${pageContext.request.contextPath}/resources/css/editReview.css">
<script>
    var selectedTags = [];

    function toggleTag(tno, button) {
        var index = selectedTags.indexOf(tno);
        if (index === -1) {
            // 태그가 선택되지 않았으면 추가
            selectedTags.push(tno);
            button.classList.add('selected');
        } else {
            // 태그가 이미 선택되었으면 제거
            selectedTags.splice(index, 1);
            button.classList.remove('selected');
        }
        // 선택된 태그 ID를 hidden input에 설정
        document.getElementById('tnos').value = selectedTags.join(',');
    }
</script>
<div class = "edit-container">
    <h2>리뷰 수정</h2>
    <form:form method="post" action="${pageContext.request.contextPath}/review" modelAttribute="review" id="review">
        <input type="hidden" name="sno" id="sno" value="${sno}" />
        <div class="form-group">
            <div class="star-rating">
                <input type="radio" name="rstar" class="star" id="star5" value="5"><label for="star5"></label>
                <input type="radio" name="rstar" class="star" id="star4" value="4"><label for="star4"></label>
                <input type="radio" name="rstar" class="star" id="star3" value="3"><label for="star3"></label>
                <input type="radio" name="rstar" class="star" id="star2" value="2"><label for="star2"></label>
                <input type="radio" name="rstar" class="star" id="star1" value="1"><label for="star1"></label>
            </div>
        </div>
        <div class="form-group">
            <form:textarea path="rcomm" id="rcomm" class="custom-textarea" placeholder="리뷰 내용을 입력하세요."></form:textarea>
        </div>
        <div class="form group">
            <p>태그를 선택하세요</p>
            <div class="tag-buttons">
                <c:forEach var="tag" items="${tags}">
                    <button type="button" class="tag-button" onclick="toggleTag(${tag.tno}, this)">${tag.ttag}</button>
                </c:forEach>
            </div>
        </div>
        <div class="form-group">
            <button type="submit" class="submit-button">리뷰 수정</button>
        </div>
        <input type="hidden" name="tnos" id="tnos" />

    </form:form>
</div>