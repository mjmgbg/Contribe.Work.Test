(function () {
	$(document).ready(function () {
		var $loading = $('#loadingDiv').hide();

		$(document)
		  .ajaxStart(function () {
		  	$loading.show();
		  })
		  .ajaxStop(function () {
		  	$loading.hide();
		  });
		updateCart = function (id) {
			var ds = $("#" + id + "-Add").attr("data-bookinstock");
			var db = $("#" + id + "-Add").attr("data-bookincart");
			var a = parseInt(ds) - 1;
			var b = parseInt(db) + 1;
			$("#" + id + "-Add").attr("data-bookinstock", a);
			$("#" + id + "-Add").attr("data-bookincart", b);
			if (a === 0 || a < 0) {
				$("#Shop").html(" <button class='fa fa-frown-o cart' disabled ></button>");
			}
			if ($("#inStock").length) {
				$("#inStock").html(a);
			}
		};
		reloadWidget = function () {
			if ($("#cart").length) {
				$("#cart").load("ShoppingCart/ReloadCartWidget");
			}
		};
		submitOrder = function (event) {
			reloadWidget();


		};
		$(".menuopt").click(function () {
			$("#search").val($(this).val());
		});
		$(".adminLink").click(function () {

		});
		setActiveColor = function (control) {
			$("#page" + control).addClass("active");

		};
	});
})();



