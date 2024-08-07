<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form" %>
<%@ taglib uri="http://java.sun.com/jstl/core_rt" prefix="c"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/fmt" prefix="fmt" %>
<div class = "all-review-div">
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
            <button type="submit" class="submit-button">리뷰 작성</button>
        </div>
        <input type="hidden" name="tnos" id="tnos" />

    </form:form>


    <h2>리뷰 목록</h2>

    <div class="dropdown" style="float: right;">
        <button class="dropdown-btn">최신순</button>
        <ul class="dropdown-content">
            <li><a href="?sort=latest">최신순</a></li>
            <li><a href="?sort=oldest">오래된순</a></li>
            <li><a href="?sort=lowRating">별점 낮은순</a></li>
            <li><a href="?sort=highRating">별점 높은순</a></li>
        </ul>
    </div>
<%--    <div class="sort-area">
        <a class = "sort-element" id="sort_by_latest" href="#">최신순</a>
        <a class = "sort-element" id="sort_by_oldest" href="#">작성순</a>
        <a class = "sort-element" id="sort_by_highest" href="#">별점 높은 순</a>
        <a class = "sort-element" id="sort_by_lowest" href="#">별점 낮은 순</a>
    </div>--%>


    <c:choose>
        <c:when test="${not empty reviews}">
            <div id="review-list">
                <c:forEach var="review" items="${reviews}">
                    <div class="review-container">
                        <div class="review-item review-item-left">${review.dateToString}</div>
                        <div class="review-item review-item-left" style="top: 35px;"><strong>${review.member.mnick}</strong></div>
                        <div class="review-item review-item-left" style="top: 60px;">
                            <span class="star-rating">
                                <c:forEach begin="${review.rstar + 1}" end="5" var="i">☆</c:forEach>
                                <c:forEach begin="1" end="${review.rstar}" var="i">★</c:forEach>
                            </span>
                        </div>
                        <div class="review-item-content">
                            <div class="review-item review-content">${review.rcomm}</div>
                            <div class="review-actions-right">
                                <c:if test="${loggedInMember != null && review.member.mno == loggedInMember.mno}">
                                    <button type="button" onclick="openEditWindow(${review.rno})">수정</button>
                                    <form method="post" action="${pageContext.request.contextPath}/review/delete" style="display: inline;">
                                        <input type="hidden" name="rno" value="${review.rno}" />
                                        <button type="submit">삭제</button>
                                    </form>
                                </c:if>
                            </div>
                        </div>
                        <div class="review-tags">
                            <c:forEach var="tag" items="${review.tags}">
                                <span class="tag-label">${tag.ttag}</span>
                            </c:forEach>
                        </div>
                    </div>
                </c:forEach>
            </div>
        </c:when>
        <c:otherwise>
            <p class="no-reviews-message">작성된 리뷰가 없습니다.</p>
        </c:otherwise>
    </c:choose>
</div>
<script>
    $(document).ready(function() {
        function loadReviewList(sortBy) {
            const sno = '${store.sno}';
            $.ajax({
                url: '${pageContext.request.contextPath}/review',
                type: 'GET',
                data: { sno: sno, sortBy: sortBy },
                success: function(response) {
                    // 받은 전체 페이지에서 필요한 부분만 추출하여 업데이트
                    const parser = new DOMParser();
                    const doc = parser.parseFromString(response, 'text/html');
                    const reviewList = doc.querySelector('#review-list').innerHTML;
                    $('#review-list').html(reviewList);
                    initializeReviewScript();
                },
                error: function(xhr, status, error) {
                    console.log('Error loading reviews:', status, error);
                }
            });
        }

        $('#sort_by_latest').click(function(event) {
            event.preventDefault();
            loadReviewList('latest');
        });

        $('#sort_by_oldest').click(function(event) {
            event.preventDefault();
            loadReviewList('oldest');
        });

        $('#sort_by_lowest').click(function(event) {
            event.preventDefault();
            loadReviewList('lowest');
        });

        $('#sort_by_highest').click(function(event) {
            event.preventDefault();
            loadReviewList('highest');
        });
    });

    document.addEventListener('DOMContentLoaded', function () {
        const dropdownBtn = document.querySelector('.dropdown-btn');
        const dropdownContent = document.querySelector('.dropdown-content');

        dropdownBtn.addEventListener('click', function (e) {
            e.stopPropagation();
            dropdownContent.style.display = dropdownContent.style.display === 'block' ? 'none' : 'block';
        });

        window.addEventListener('click', function () {
            if (dropdownContent.style.display === 'block') {
                dropdownContent.style.display = 'none';
            }
        });
    });
</script>


