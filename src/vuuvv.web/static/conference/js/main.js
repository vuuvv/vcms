
$(function() {
	var delta = -270 + ($("#wrapper").width() - $("#wrapper-inner").width()) / 2;
	$(".fixed").width($("#wrapper-inner").width());
	$(".header-inner").css("background-position", delta + "px");
	$(window).resize(function() {
		delta = -270 + ($("#wrapper").width() - $("#wrapper-inner").width()) / 2;
		$(".fixed").width($("#wrapper-inner").width());
		$(".header-inner").css("background-position", delta + "px");
	});

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

	move_to(origin_tab);

	$(".header-nav-link").hover(function() {
		var $this = $(this),
			index = parseInt($this.attr("index"));
		move_to(index);
	});
	$(".header-nav").hover(function(){}, function() {
		move_to(origin_tab);
	});

	$("body").removeClass("loading");
});
