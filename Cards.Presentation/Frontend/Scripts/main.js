(function($) {
  var app = {};

  app.behaviors = {
    states: {
      active: 'active',
      hidden: 'hidden',
      shown: 'shown'
    },
    activate: function($target) {
      $target.addClass(app.behaviors.states.active);
    },
    deactivate: function($target) {
      $target.removeClass(app.behaviors.states.active);
    },
    hide: function ($targets) {
      $targets.removeClass(app.behaviors.states.shown).addClass(app.behaviors.states.hidden);
    },
    show: function ($targets) {
      $targets.removeClass(app.behaviors.states.hidden).addClass(app.behaviors.states.shown);
    },
    init: function() {
      $('[data-shows]').on('click', function(event) {
        app.behaviors.show($($(this).data('shows')));
        event.preventDefault();
      });
      $('[data-hides]').on('click', function(event) {
        app.behaviors.hide($($(this).data('hides')));
        event.preventDefault();
      });
      $('[data-activates]').on('click', function(event) {
        app.behaviors.activate($($(this).data('activates')));
        event.preventDefault();
      });
      $('[data-deactivates]').on('click', function(event) {
        app.behaviors.deactivate($($(this).data('deactivates')));
        event.preventDefault();
      });
    }
  };

  app.init = function () {
    app.behaviors.init();
  };

  $(function() {
    app.init();
  });
})(jQuery);