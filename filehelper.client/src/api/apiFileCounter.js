import axiosInstance from './axios-instance';

class ApiFileCounter {
    countXmlFiles = (directory) => {
        return axiosInstance.post('/filecounter',
            directory,
            {headers: {'Content-Type': 'application/json'}}
        )
    };
}

const apiFileCounter = new ApiFileCounter();
export default apiFileCounter;