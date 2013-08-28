$(function () {
  var hub = $.connection.LobbyHub,
      apiUrl = "/api/LobbyApi/";

  function addGameToList(game) {
    var gameList = $("#games"),
        node = $("<li id=\"" + game.Id + "\" onclick=\"\">" + game.GameType + ", players: <span class=\"players\">" + game.CurrentPlayers + "</span>/" + game.MaxPlayers + "</li>");

    node.on('click', function () {
      joinGame(game.Id, game.GameType);
    });
    
    gameList.append(node);
  }

  hub.client.addGameToList = addGameToList;

  hub.client.updatePlayerCount = function (gameId, newCount) {
    $("#" + gameId + " .players", "#games").text(newCount);
  };

  hub.client.playersChanged = function (newNumber) {
    $("#playerCount").text(newNumber);
  };

  function joinGame(id, type) {
    var gametypeHub = $.connection[type];
    
    gametypeHub.server.joinGame(id)
      .done(function () {
        window.location.href = "/Home/Game";
      })
      .fail(function () {
        alert("failed");
      });
  }

  $.connection.hub.start().done(function () {
    $.getJSON(apiUrl + "GetAvailableGameTypes")
      .done(function (data) {
        // On success, 'data' contains a list of products.
        $.each(data, function (key, item) {
          var btn = $("<button>" + item + "</button>");
          // Add a list item for the product.
          btn.appendTo($('#gameTypes'));

          btn.on('click', function () {
            var gametypeHub = $.connection[item];

            gametypeHub.server.createGame().done(function () {
              window.location.href = "/Home/Game";
            }).fail(function () {
              alert("Fail");
            });
          });
        });
      });
    
    $.getJSON(apiUrl + "GetAvailableGames")
      .done(function (games) {
        $.each(games, function (i, game) {
          addGameToList(game);
        });
      });
  });
});