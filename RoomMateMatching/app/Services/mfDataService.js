
roomMateMatchingApp.factory('mfDataService',
    ['$http', function ($http) {
        
        var insertAnswers = function(answers) {
            return $http.post("MatchingForm/Insert", answers);
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
                Answer10: "5",
                Importance01: "1",
                Importance02: "2",
                Importance03: "3",
                Importance04: "1",
                Importance05: "2",
                Importance06: "3",
                Importance07: "1",
                Importance08: "2",
                Importance09: "3",
                Importance10: "1"
            };
        };

        return {
            insertAnswers: insertAnswers,
            getAnswers: getAnswers
        };
    }]);