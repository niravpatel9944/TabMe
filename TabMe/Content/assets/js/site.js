!function (e, t, n) { "use strict"; n.extend(e.site, { init: function () { void 0 !== site.menubar && (site.menubar.init(), n(t).on("click", ".hamburger", function (e) { n(this).toggleClass("is-active") }), n(t).on("click", '[data-toggle="menubar-fold"]', function (e) { site.menubar.toggleFold(), e.preventDefault() }), n(t).on("click", '[data-toggle="menubar"]', function (e) { site.menubar.toggle(), e.preventDefault() }), n(e).on("resize orientationchange", function () { site.menubar.scroll.update() }), n(t).on("click", ".submenu-toggle", function (e) { site.menubar.menu.toggleOnClick(n(this)), e.preventDefault() }), n(t).on("mouseenter mouseleave", "body.menubar-fold .site-menu > li", function (e) { site.menubar.menu.toggleOnHover(n(this)), e.preventDefault() }), n(t).on("click", '[data-toggle="collapse"]', function (e) { var t = n(e.target); t.is('[data-toggle="collapse"]') || (t = t.parents('[data-toggle="collapse"]')), "site-navbar-collapse" === n(t.attr("data-target")).attr("id") && n("body").toggleClass("navbar-collapse-in"), e.preventDefault() }), Breakpoints.on("change", function () { site.menubar.change(), n('[data-toggle="menubar"]').toggleClass("is-active", site.menubar.opened), n('[data-toggle="menubar-fold"]').toggleClass("is-active", !site.menubar.folded) })), !/xs|sm/.test(Breakpoints.current().name) && n(".scroll-container").perfectScrollbar(), this.initPlugins() } }) }(window, document, jQuery), $(function () { site.init() });

$(document).ready(function () {
    $("#input-freqd-1").fileinput({
        uploadUrl: "/file-upload-batch/2",
        showUpload: false,
        showRemove: false,
        required: true,
        allowedFileExtensions: ["jpg", "png", "gif"]
    });
    $('.textarea.wysihtml').wysihtml5();
    $(function () {
        $('#datetimepicker1').datetimepicker({
            format: 'LT'
        });
        $('#datetimepicker2').datetimepicker({
            format: 'LT'
        });
        $('#datetimepicker3').datetimepicker({
            format: 'LT'
        });
        $('#datetimepicker4').datetimepicker({
            format: 'LT'
        });
        $('#datetimepicker5').datetimepicker({
            format: 'LT'
        });
        $('#datetimepicker6').datetimepicker({
            format: 'LT'
        });
        //$("#checkAll").click(function () {
        //    $('input:checkbox').not(this).prop('checked', this.checked);
        //});
        $("#checkedAll").change(function () {
            if (this.checked) {
                $(".checkSingle").each(function () {
                    this.checked = true;
                })
            } else {
                $(".checkSingle").each(function () {
                    this.checked = false;
                })
            }
        });
        $(".checkSingle").click(function () {
            if ($(this).is(":checked")) {
                var isAllChecked = 0;
                $(".checkSingle").each(function () {
                    if (!this.checked)
                        isAllChecked = 1;
                })
                if (isAllChecked == 0) { $("#checkedAll").prop("checked", true); }
            } else {
                $("#checkedAll").prop("checked", false);
            }
        });
    });

    $('.checkbox #Room_IsPeak').change(function () {
        if ($(this).is(':checked'))
            $(".add_peak_time").show();
        else
            $(".add_peak_time").hide();
    });
    $('.checkbox #Room_IsCustomRateTiming').change(function () {
        if ($(this).is(':checked'))
            $(".add_custom_time").show();
        else
            $(".add_custom_time").hide();
    });
    $('.checkbox #Room_IsMinSpend').change(function () {
        if ($(this).is(':checked'))
            $(".IsMinSpend_area").show();
        else
            $(".IsMinSpend_area").hide();
    });
});