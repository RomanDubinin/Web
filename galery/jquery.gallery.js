(function($, undefined){
	function step(direct,shag,speed,easing){
		var marginLeft = parseInt($carusel.css('marginLeft'));// текущее положение карусели
		var wdth = caruselWidth() - galleryWidth; // максимальная прокрутка влево
		if( direct > 0 ){
			// прокрутка влево
			// если текущая прокрутка + shag не превышает максимально допустимую
			if( wdth >= Math.abs(marginLeft)+shag ){
				// то просто прокручиваем на shag
				$carusel.stop().animate({'marginLeft':'-='+shag+'px'},speed,easing)
			// иначе докручиваем до края, и все
			}else $carusel.stop().animate({'marginLeft':'-'+wdth+'px'},speed,easing)
		}else{
			// аналогично для прокрутки вправо, но тут крутим до нуля
			if( 0 <= Math.abs(marginLeft)-shag ){
				$carusel.stop().animate({'marginLeft':'+='+shag+'px'},speed,easing)
			}else $carusel.stop().animate({'marginLeft':'0px'},speed,easing)
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

    $('.bigImg')
        .fadeOut();

});
	
	$('.photo').on("click", function(e) {
    $('.display')
        .show()
        .css('opacity', 0)
        .animate({
            'opacity': '0.7'
        }, 'slow');

    $('.bigImg')
        .show(700);

    var addr = e.target.src;
    $('.loader').css('display','block');
    $('.bImg').attr('src', addr);
    $('.bImg').load(function (){
        $('.loader').css('display','none');
    });


});
	
	var galleryWidth = 0; // ширина самой галлереи
	var shag = 700; // при каждом шаге будем двигать карусель на 100 пиксел
	var speed = 200; // время в миллисекундах, за которое галерея пройдет 1 шаг, т.е. сдвинется на shag или 200px
	var $gallery  = 0; // вспомогательные переменные, они пригодятся, когда мы будем делать плагин
	var $carusel = 0; // хороший тон находить элемент единожды, а потом использовать ссылку на него
	var $items = 0;
	$(document).ready(function(){
		// запускать функцию надо только после того, как DOM полностью загружен
		$gallery = $('.gallery'); // находим нашу галерею
		$carusel = $gallery.find('.carusel');// находим в ней карусель
		$items = $carusel.find('a');
		galleryWidth = $gallery.width()
		$gallery.find('div.next,div.prev')
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