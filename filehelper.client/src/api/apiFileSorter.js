import axiosInstance from './axios-instance';

class ApiFileSorter {
    sortXmlFile = (file) => {
        return axiosInstance.post('/filersorter',
            file,
            {headers: {'Content-Type': 'application/json'}}
        )
    };
}

const apiFileSorter = new ApiFileSorter();
export default apiFileSorter;