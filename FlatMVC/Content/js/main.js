

// Document ready
$(function() {

       
/*-----------------------------------------------------------------------------------*/
/*	01. PARALLAX SETTING
/*-----------------------------------------------------------------------------------*/
	

  $(document).ready(function(){	
	//.parallax(xPosition, speedFactor, outerHeight) options:
	//xPosition - Horizontal position of the element
	//inertia - speed to move relative to vertical scroll. Example: 0.1 is one tenth the speed of scrolling, 2 is twice the speed of scrolling
	//outerHeight (true/false) - Whether or not jQuery should use it's outerHeight option to determine when a section is in the viewport
	$('#header').parallax("10%", 1.5);	
})

/*-----------------------------------------------------------------------------------*/
/*	02. NAVBAR STICKY + SELECTED
/*-----------------------------------------------------------------------------------*/
	


var cbpAnimatedHeader = (function() {

	var docElem = document.documentElement,
		header = document.querySelector( '.cbp-af-header' ),
		didScroll = false,
		changeHeaderOn = 10;

	function init() {
		window.addEventListener( 'scroll', function( event ) {
			if( !didScroll ) {
				didScroll = true;
				setTimeout( scrollPage, 100 );
			}
		}, false );
	}

	function scrollPage() {
		var sy = scrollY();
		if ( sy >= changeHeaderOn ) {
			classie.add( header, 'cbp-af-header-shrink' );
		}
		else {
			classie.remove( header, 'cbp-af-header-shrink' );
		}
		didScroll = false;
	}

	function scrollY() {
		return window.pageYOffset || docElem.scrollTop;
	}

	init();

})();
	var sections = $("section");
	var navigation_links = $("nav a");
	
	sections.waypoint({
		handler: function(event, direction) {
		
			var active_section;
			active_section = $(this);
			if (direction === "up") active_section = active_section.prev();

			var active_link = $('nav a[href="#' + active_section.attr("id") + '"]');
			navigation_links.removeClass("selected");
			active_link.addClass("selected");

		},
		offset: '30'
	})

});


/*-----------------------------------------------------------------------------------*/
/*	03. SMOOTH SCROLLING
/*-----------------------------------------------------------------------------------*/
	

$('nav a, .buttongo a').click(function(e){
    $('html,body').scrollTo(this.hash,this.hash);
    e.preventDefault();
});



/*-----------------------------------------------------------------------------------*/
/*	04. ISOTOPE PROJECTS & FILTERS
/*-----------------------------------------------------------------------------------*/


$(document).ready(function () {
    var $container = $('#projects_grid .items');
    
    $container.imagesLoaded(function () {
        $container.isotope({
            itemSelector: '.item',
            layoutMode: 'fitRows',
            filter: '*'
        });
    });

    $('.filter li a').click(function () {

        $('.filter li a').removeClass('active');
        $(this).addClass('active');

        var selector = $(this).attr('data-filter');
        $container.isotope({
            filter: selector
        });

        return false;
    });
});


/*-----------------------------------------------------------------------------------*/
/*	05. PROJECTS PORTFOLIO HOVER
/*-----------------------------------------------------------------------------------*/
$(function () {
    $(' .items > li, .frame > a ').each(function () {
        $(this).hoverdir();
    });
});

/*-----------------------------------------------------------------------------------*/
/*	06. RESPONSIVE MENU
/*-----------------------------------------------------------------------------------*/

		jQuery("#collapse").hide();
		jQuery("#collapse-menu").on("click", function () {
		
		    jQuery("#collapse").slideToggle(300);
		    return false;
		    
		}, function () {
		    
		    jQuery("#collapse").slideToggle(300);
		    return false;
		});


