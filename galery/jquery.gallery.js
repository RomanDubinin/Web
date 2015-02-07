(function($, undefined){
	function step(direct,shag,speed,easing){
		var marginLeft = parseInt($('.carusel').css('marginLeft'));// ������� ��������� ��������
		var wdth = caruselWidth() - $('.gallery').width(); // ������������ ��������� �����
		if( direct > 0 ){
			// ��������� �����
			// ���� ������� ��������� + shag �� ��������� ����������� ����������
			if( wdth >= Math.abs(marginLeft)+shag ){
				// �� ������ ������������ �� shag
				$('.carusel').stop().animate({'marginLeft':'-='+shag+'px'},speed,easing)
			// ����� ����������� �� ����, � ���
			}else $('.carusel').stop().animate({'marginLeft':'-'+wdth+'px'},speed,easing)
		}else{
			// ���������� ��� ��������� ������, �� ��� ������ �� ����
			if( 0 <= Math.abs(marginLeft)-shag ){
				$('.carusel').stop().animate({'marginLeft':'+='+shag+'px'},speed,easing)
			}else $('.carusel').stop().animate({'marginLeft':'0px'},speed,easing)
		}
	}
	
	var caruselWidth = function(){
		var w = 0;
		$items.each(function(){
			w+=$(this).find('img').width()+5;
		})
		return w;
	}
	
	$('.display, .close').on("click", function(e) {
    
    $('.display')
        .fadeOut();

    $('.bigImgSrc')
        .fadeOut();
		
	$('.close').fadeOut()
	$('.prev').show()
	$('.next').show()

});
	
	$('.photo').on("click", function(e) {
    $('.display')
        .show()
        .css('opacity', 0)
        .animate({
            'opacity': '0.7'
        }, 'slow');
	$('.close').show()
	$('.prev').fadeOut()
	$('.next').fadeOut()
	
    $('.loader').css('display','block');
    $('.bigImgSrc').load(function (){
        $('.loader').css('display','none');
    });
	$('.bigImgSrc').attr('src', e.target.src);
	$('.bigImgSrc')
			.show(300);
});
	
	var shag = 700; // ��� ������ ���� ����� ������� �������� �� 100 ������
	var speed = 200; // ����� � �������������, �� ������� ������� ������� 1 ���, �.�. ��������� �� shag ��� 200px
	var $items = 0;
	$(document).ready(function(){
		$items = $('.carusel').find('a');
		$('.gallery').find('div.next,div.prev')
		.hover(function(){
			$(this).stop().animate({'opacity':'0.8'},400);
			},function(){
			$(this).stop().animate({'opacity':'0.5'},400);
			})
			.click(function(){
			step(this.className=='next'?1:-1,shag,speed,'linear');
		})
		
		
	})
	
	
})(jQuery);