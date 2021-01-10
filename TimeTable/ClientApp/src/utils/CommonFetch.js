var serviceUrl = "http://localhost:8000";

export const CommonGet = (url, queryString) => {
    return new Promise((resolve, reject) => {
        let request  = new XMLHttpRequest();
        if (queryString != null) {
            request.open("GET", serviceUrl + url +"?" + queryString);
        } else {
            request.open("GET", serviceUrl + url);
        }

        request.setRequestHeader("Content-type", "application/json; charset=utf-8");
       // request.setRequestHeader('Authorization', 'Bearer ' + window.access_token);
        //request.setRequestHeader('Access-Control-Allow-Methods', '*');
        request.onload = () => {

            if (request.status >= 200 && request.status < 300) {
               // console.log("response header ",request.response);
                resolve(JSON.parse(request.response));
            } else {
                reject(request.statusText);
            }
            
        };
        
        request.onerror = () => reject(request.statusText);
        request.send();
    });
};

export const CommonPost = (url, queryString, body) => {
    const result = JSON.stringify(body);
    return new Promise((resolve, reject) => {
        let request = new XMLHttpRequest();
        if (queryString != null) {
            request.open("POST", serviceUrl + url +"?"+ queryString);
        } else {
            request.open("POST", serviceUrl + url);
        }

        request.setRequestHeader("Content-type", "application/json; charset=utf-8");
        request.setRequestHeader('Authorization', 'Bearer ' + window.access_token);
        request.setRequestHeader('Access-Control-Allow-Methods', '*');
        request.onload = () => {
            if (request.status >= 200 && request.status < 300) {
                resolve(JSON.parse(request.response));
            } else {
                reject(request.statusText);
            }
        };
        request.onerror = () => reject(request.statusText);
        request.send(result);
    });
};
