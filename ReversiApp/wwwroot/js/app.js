"use strict";

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }

function _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }

var gameURL = "/Spel/Get/";
var WeatherURL = "http://api.openweathermap.org/data/2.5/weather?q=zwolle&apikey=92cd3e30e7183d1187b6dc09432ce384";

var Game = function (url) {
  console.log('hallo, vanuit een module\n' + url); //Configuratie en state waarden

  var configMap = {
    apiUrl: url
  };
  var stateMap = {
    gameState: 2
  };

  var _getCurrentGameState = function _getCurrentGameState() {
    stateMap.gameState = Game.Model.getGameState("test");
  }; // Private function init


  var privateInit = function privateInit(afterInit) {
    console.log(configMap.apiUrl); //const intervalID = window.setInterval(_getCurrentGameState, 2000);

    afterInit();
  }; // Waarde/object geretourneerd aan de outer scope


  return {
    init: privateInit
  };
}(gameURL);

Game.Reversi = function () {
  var privateInit = function privateInit() {};

  console.log('hallo, vanuit module Reversi');
  var configMap = {
    apiUrl: gameURL
  };

  function startZet(id) {
    //Id uit elkaar halen zodat er een x en y coordinaat onstaat
    var x;
    var y;

    if (id.charAt(0) >= 0 && id.charAt(0) <= 7) {
      x = id.charAt(0);
    }

    if (id.charAt(2) >= 0 && id.charAt(2) <= 7) {
      y = id.charAt(2);
    } //Geef hokje aan de speler (Of dit kan/mag moet serverside afgevangen worden)


    var url = "../../api/Reversi/DoeZet/" + x + "/" + y;
    Game.Data.get(url).then(function (zetData) {
      window.location.reload(true);
    })["catch"](function (e) {
      console.log(e.message);
    }); //Server get aandebeurt (1=wit, 2=zwart)

    var urlBeurt = gameURL + "AandeBeurt/4659129";
    Game.Data.get(urlBeurt).then(function (gameData) {
      var beurt = gameData.aandeBeurt;
      showFiche(x, y, beurt);
    });
  }

  function showFiche(x, y, colour) {
    var cell = document.getElementById("spelbord").rows[x].cells[y];

    if (cell.hasChildNodes()) {
      return Error("Het veld is al ingevuld");
    }

    if (colour == 2) {
      $(cell).append("<div class='fiche--zwart'></div>");
    } else if (colour == 1) {
      $(cell).append("<div class='fiche--wit'></div>");
    }

    Game.API.getResponse();
  }

  function showFicheNoAnimation(x, y, colour) {
    var cell = document.getElementById("spelbord").rows[x].cells[y];

    if (cell.hasChildNodes()) {
      return Error("Het veld is al ingevuld");
    }

    if (colour == 2) {
      $(cell).append("<div class='fiche--zwart-static'></div>");
    } else if (colour == 1) {
      $(cell).append("<div class='fiche--wit-static'></div>");
    }
  }

  function showBord(gameToken) {
    var url = gameURL + gameToken;
    Game.Data.get(url).then(function (gameData) {
      var JsonBord = gameData.bord;

      if (JsonBord !== "undefined") {
        var gameBoardArray = JSON.parse(JsonBord);
        var template = Game.Template.getTemplate(['features', 'spelbord'])({
          bord: gameBoardArray
        }); //let html = $.parseHTML(template), nodeNames = [];

        $("#spelbord").replaceWith(template); // var i;
        // for (i = 0; i < 8; i++) {
        //     var rowArray = gameBoardArray[i];
        //     var j;
        //     for (j = 0; j < 8; j++) {
        //         if (rowArray[j] === 1) {
        //             showFicheNoAnimation(i, j, 1);
        //         } else if (rowArray[j] === 2) {
        //             showFicheNoAnimation(i, j, 2);
        //         }
        //     }
        // }
      } else {
        console.log("something went wrong");
      }
    })["catch"](function (e) {
      console.log(e.message);
    });
  }

  function setUpAPI() {}

  return {
    publicInit: privateInit,
    startZet: startZet,
    showBord: showBord,
    showFiche: showFiche,
    setUpAPI: setUpAPI
  };
}();

Game.Data = function () {
  var configMap = {
    apiKey: '92cd3e30e7183d1187b6dc09432ce384',
    mock: [{
      url: "api/Spel/Beurt",
      data: 0
    }]
  };
  var stateMap = {
    environment: 'production'
  };

  var getMockData = function getMockData(url) {
    var mockData = configMap.mock;
    return new Promise(function (resolve, reject) {
      resolve(mockData);
    });
  };

  var init = function init(environment) {
    stateMap.environment = environment;

    if (stateMap.environment == "development") {
      return getMockData(url);
    } else if (stateMap.environment == "production") {
      //Request server
      return $.get(url).then(function (r) {
        return r;
      })["catch"](function (e) {
        console.log(e.message);
      });
    } else {
      new Error("Environment is not recognised");
    }
  };

  var get = function get(url) {
    if (stateMap.environment == "development") {
      return getMockData(url);
    } else if (stateMap.environment == "production") {
      //Request server
      return $.get(url).then(function (r) {
        return r;
      })["catch"](function (e) {
        console.log(e.message);
      });
    }
  };

  var privateInit = function privateInit() {// doing private things...
  };

  return {
    publicInit: privateInit,
    get: get
  };
}();

Game.Model = function () {
  var configMap;

  var getWeather = function getWeather(url) {
    Game.Data.get(WeatherURL).then(function (weather) {
      var temperature = weather.main.temp;

      if (temperature !== undefined) {
        console.log("Weather is: " + Math.round(temperature - 273.15) + " C°");
      } else {
        throw "TEMP IS UNAVAILABLE";
      }
    })["catch"](function (e) {
      console.log(e.message);
    });
  };

  var _getGameState = function _getGameState() {
    //aanvraag via Game.Data
    var gameState = Game.Data.get("/api/Reversi/Beurt/test"); //controle of ontvangen data valide is

    if (gameState === 0 || gameState === 1 || gameState === 2) {} else {
      new Error("Waarde is niet 0,1,2");
    }
  };

  var privateInit = function privateInit() {// doing private things...
  };

  return {
    publicInit: privateInit,
    getWeather: getWeather,
    getGameState: _getGameState
  };
}();

Game.Template = function () {
  var getTemplate = function getTemplate(templateName) {
    var temp = spa_templates;
    templateName.forEach(function (item) {
      temp = temp[item];
    });
    return temp;
  };

  return {
    getTemplate: getTemplate
  };
}();

Game.API = function () {
  var getResponse = function getResponse() {
    var settings = {
      "async": true,
      "crossDomain": true,
      "url": "https://api.thecatapi.com/v1/images/search",
      "method": "GET",
      "headers": {
        "x-api-key": "DEMO-API-KEY"
      }
    };
    $.ajax(settings).done(function (response) {
      var imageUrl = response[0].url;
      document.getElementById("cat").src = imageUrl;
      document.getElementById("cat").style.display = 'block';
      setTimeout(function () {
        document.getElementById("cat").style.display = 'none';
      }, 4500);
    });
  };

  return {
    getResponse: getResponse
  };
}();

Game.Stats = new function () {
  var configMap = {
    property: null
  };

  var init = function init() {
    console.log(configMap.apiUrl);
  };

  var getWhiteStones = function getWhiteStones(token) {
    var url = gameURL + token;
    return Game.Data.get(url).then(function (gameData) {
      var bord = gameData.bord;

      if (bord !== undefined) {
        var gameBoardArray = JSON.parse(bord);
        var AmountWhiteStones = 0;

        for (var i = 0; i < 8; i++) {
          var rowArray = gameBoardArray[i];

          for (var j = 0; j < 8; j++) {
            if (rowArray[j] === 1) {
              AmountWhiteStones++;
            }
          }
        }

        if (AmountWhiteStones > 0) {
          console.log("White stones: " + AmountWhiteStones);
          return AmountWhiteStones;
        } else {
          console.log("No white stones were found...");
          return 0;
        }
      }
    })["catch"](function (e) {
      console.log(e.message);
    });
  };

  var getBlackStones = function getBlackStones(token) {
    var url = gameURL + token;
    return Game.Data.get(url).then(function (gameData) {
      var bord = gameData.bord;

      if (bord !== "undefined") {
        var gameBoardArray = JSON.parse(bord);
        var AmountBlackStones = 0;

        for (var i = 0; i < 8; i++) {
          var rowArray = gameBoardArray[i];

          for (var j = 0; j < 8; j++) {
            if (rowArray[j] === 2) {
              AmountBlackStones++;
            }
          }
        }

        if (AmountBlackStones > 0) {
          console.log("Black: " + AmountBlackStones);
          return Number(AmountBlackStones);
        } else {
          console.log("No black stones were found...");
          return 0;
        }
      }
    })["catch"](function (e) {
      console.log(e.message);
    });
  };

  return {
    init: init,
    getWhiteStones: getWhiteStones,
    getBlackStones: getBlackStones
  };
}();

var FeedbackWidget = /*#__PURE__*/function () {
  function FeedbackWidget(elementId) {
    _classCallCheck(this, FeedbackWidget);

    this._elementId = elementId;
  }

  _createClass(FeedbackWidget, [{
    key: "show",
    value: function show(message, type) {
      var x = document.getElementById(this.elementId);
      x.style.display = "block";
      x.style.animationDuration = "2.5s";
      x.style.animationName = "fadeIn";
      x.textContent = message;

      if (type == "success") {
        x.setAttribute("class", "alert alert-success");
      } else {
        x.setAttribute("class", "alert alert-danger");
      }

      var ObjectMessage = {
        message: message,
        status: status
      };
      this.log(JSON.stringify(ObjectMessage));
    }
  }, {
    key: "hide",
    value: function hide() {
      var x = document.getElementById(this.elementId);
      x.style.animation = "fadeOut";
    }
  }, {
    key: "log",
    value: function log(message) {
      if (localStorage.getItem('feedback_widget') !== null) {
        var array = JSON.parse(localStorage.getItem('feedback_widget'));

        if (array.length === 10) {
          array.shift();
        }
      } else {
        var array = [];
      }

      array.push(message);
      var arrayString = JSON.stringify(array);
      localStorage.setItem('feedback_widget', arrayString);
    }
  }, {
    key: "removeLog",
    value: function removeLog() {
      localStorage.removeItem('feedback_widget');
    }
  }, {
    key: "history",
    value: function history() {
      if (localStorage.getItem('feedback_widget') !== null) {
        var array = JSON.parse(localStorage.getItem('feedback_widget'));
        var stringHistory = "";
        var a = array.length - 1;
        array.forEach(function (obj) {
          var pObj = obj;
          var addstring = "type " + pObj.type + " - " + pObj.message;

          if (a > 0) {
            a--;
            addstring += "\n";
          }

          stringHistory += addstring;
        });
        return stringHistory;
      }
    }
  }, {
    key: "elementId",
    get: function get() {
      //getter, set keyword voor setter methode
      return this._elementId;
    }
  }]);

  return FeedbackWidget;
}();

var f = new FeedbackWidget('feedback-widget');