
roomMateMatchingApp.factory('mfDataService',
    ['$http', function ($http) {
        
        var insertAnswers = function(answers) {
            return $http.post("MatchingForm/Insert", answers);
        }

        var getAnswers = function() {
            return {
                Answer01: null,
                Answer02: null,
                Answer03: null,
                Answer04: null,
                Answer05: null,
                Answer06: null,
                Answer07: null,
                Answer08: null,
                Answer09: null,
                Answer10: null,
                Importance01: null,
                Importance02: null,
                Importance03: null,
                Importance04: null,
                Importance05: null,
                Importance06: null,
                Importance07: null,
                Importance08: null,
                Importance09: null,
                Importance10: null
            };
        };

        return {
            insertAnswers: insertAnswers,
            getAnswers: getAnswers
        };
    }]);