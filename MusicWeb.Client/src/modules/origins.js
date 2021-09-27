import originServices from "@/services/originServices";

export default function useOrigins() {
    const getCountryById = function (id) {
        if (id) {
            return originServices.getCountryById(id).then((response) => {
                return response.data.name;
            });
        }
    };
    const getStateById = function (id) {
        if (id) {
            return originServices.getStateById(id).then((response) => {
                return response.data.name;
            });
        }
    };
    const getCityById = function (id) {
        if (id) {
            return originServices.getCityById(id).then((response) => {
                return response.data.name;
            });
        }
    };
    return {
        getCountryById,
        getStateById,
        getCityById,
    };
}
