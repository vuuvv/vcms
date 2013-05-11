
$(function() {
	/* index tune */
	function fBodyVericalAlign(){
		var nBodyHeight = 572;
		var nClientHeight = document.documentElement.clientHeight;
		if(nClientHeight >= nBodyHeight + 2){
			var nDis = (nClientHeight - nBodyHeight)/2;
			document.body.style.paddingTop = nDis + 'px';
		}else{
			document.body.style.paddingTop = '0px';
		}
	} 
	fBodyVericalAlign();
	$(window).bind("resize", fBodyVericalAlign);

	/* arrow move */
	var arrow = $("#nav-arrow");
	var start = 8;
	var cur = 0;

	var move_to = function(index) {
		if (cur === index) 
			return;
		arrow.stop();
		$(".header-nav-link[index=" + cur + "]").removeClass("cur");
		arrow.animate({
			left: index * 85 + start
		}, 100, function() {
			$(".header-nav-link[index=" + index + "]").addClass("cur");
			cur = index;
		});
	};

	$(".header-nav-link").hover(function() {
		var $this = $(this),
			index = parseInt($this.attr("index"));
		move_to(index);
	});
	$(".header-nav").hover(function(){}, function() {
		move_to(0);
	});

	$("body").removeClass("loading");
});
