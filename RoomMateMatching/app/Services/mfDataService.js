
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
                Answer10: null
            };
        };

        return {
            insertAnswers: insertAnswers,
            getAnswers: getAnswers
        };
    }]);