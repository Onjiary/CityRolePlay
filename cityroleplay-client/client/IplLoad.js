/// <reference types="@altv/types-client" />
/// <reference types="@altv/types-natives" />

import * as alt from 'alt-client';
import * as native from 'natives';

alt.on("connectionComplete",()=>{
    alt.requestIpl("rc12b_default");
    alt.requestIpl("shr_int");
    alt.requestIpl("golfflags");
    alt.requestIpl("FIBlobby");
    alt.requestIpl("post_hiest_unload");
    alt.requestIpl("refit_unload");
    alt.requestIpl("TrevorsTrailerTidys");
    alt.requestIpl("Carwash_with_spinners");
});