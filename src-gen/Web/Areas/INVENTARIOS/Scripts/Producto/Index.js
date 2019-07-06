var Index = function () {
    "use strict";
    return {
        // ---------------------------------
        //           Propiedades 
        // ---------------------------------
        actionTemplate: null,

        // ---------------------------------
        //           Metodos 
        // ---------------------------------

        init: function () {
            console.log("((init))");
            this.handleTemplates();
        },

        handleTemplates: function () {
            this.actionTemplate = kendo.template($('#Index #actionTemplate').html());
        }
		

        
    };
}();
