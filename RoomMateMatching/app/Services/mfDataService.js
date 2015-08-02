
roomMateMatchingApp.factory('mfDataService',
    ['$http', function ($http) {
        
        var insertAnswers = function(newAnswers) {
            return $http.post("MatchingForm/Insert" , newAnswers);
        }

        var getAnswers = function() {
            return {
                Answer01: "1",
                Answer02: "2",
                Answer03: "3",
                Answer04: "4",
                Answer05: "5",
                Answer06: "1",
                Answer07: "2",
                Answer08: "3",
                Answer09: "4",
                Answer10: "5"
            };
        };

        return {
            insertAnswers: insertAnswers,
            getAnswers: getAnswers
        };
    }]);