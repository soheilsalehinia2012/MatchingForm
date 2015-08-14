roomMateMatchingApp.factory('authenticationService',
    function () {
        var isAuthenticated = false;
        var stdNum = null;

        function setIsAuthenticated(isauth) {
            isAuthenticated = isauth;
        }

        function getIsAuthenticated() {
            return isAuthenticated;
        }

        function getStdNum() {
            return stdNum;
        }

        function setStdNum(stdnum) {
            stdNum = stdnum;
        }

        

        return {
            setIsAuthenticated: setIsAuthenticated,
            getIsAuthenticated: getIsAuthenticated,
            getStdNum: getStdNum,
            setStdNum: setStdNum
        };

    });