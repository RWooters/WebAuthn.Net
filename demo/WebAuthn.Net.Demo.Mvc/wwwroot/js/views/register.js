(() => {
    const checkboxElements = [
        () => document.getElementById("allowed-algo-RS1"),
        () => document.getElementById("allowed-algo-RS512"),
        () => document.getElementById("allowed-algo-RS384"),
        () => document.getElementById("allowed-algo-RS256"),
        () => document.getElementById("allowed-algo-PS512"),
        () => document.getElementById("allowed-algo-PS384"),
        () => document.getElementById("allowed-algo-PS256"),
        () => document.getElementById("allowed-algo-ES512"),
        () => document.getElementById("allowed-algo-ES384"),
        () => document.getElementById("allowed-algo-ES256"),
        () => document.getElementById("allowed-algo-EDDSA"),
    ];
    const formElements = {
        authenticatorAttachment: () => document.getElementById("webauthn-params-authenticator-attachment"),
        residentKey: () => document.getElementById("webauthn-params-resident-key"),
        userVerification: () => document.getElementById("webauthn-params-user-verification"),
        attestation: () => document.getElementById("webauthn-params-attestation")
    };
    const elements = {
        registerInput: () => document.getElementById("webauthn-register-name"),
        registerButton: () => document.getElementById("webauthn-register-submit"),
        registerOptionsReset: () => document.getElementById("webauthn-params-submit"),
        csrfElement: () => document.getElementById("webauthn-register-request-token")
    };
    const defaultParams = {
        pubKeyCredParams: [
            -65535,
            -259,
            -258,
            -257,
            -39,
            -38,
            -37,
            -36,
            -35,
            -7,
            -8
        ],
        authenticatorAttachment: "unset",
        residentKey: "unset",
        userVerification: "preferred",
        attestation: "none",
    };
    const {createRegistrationOptions, completeRegistration} = API.Register;
    const {
        getState,
        setState,
        resetState,
        withState,
        ensureStateCreated
    } = createStateMethods({key: localStateKeys.registrationParamsKey, defaultParams});

    // DOM Handlers
    const onRegisterButtonHandler = async (e) => {
        e.preventDefault();
        const registrationParameters = getState();
        const username = getElementValue(elements.registerInput());
        const csrf = getElementValue(elements.csrfElement());

        if (!isValidString(username)) {
            Alerts.usernameInputEmpty();
            clearElementValue(elements.registerInput());
            return;
        }

        const registrationOptions = await createRegistrationOptions({registrationParameters, username, csrf});
        if (!registrationOptions) return;
        const publicKey = {
            ...registrationOptions,
            challenge: coerceToArrayBuffer(registrationOptions.challenge),
            user: {
                ...registrationOptions.user,
                id: coerceToArrayBuffer(registrationOptions.user.id),
            },
            excludeCredentials: (registrationOptions.excludeCredentials ?? []).map(x => ({
                ...x,
                id: coerceToArrayBuffer(x.id)
            }))
        };

        let newCredential;
        try {
            newCredential = await navigator.credentials.create({publicKey});
            if (!newCredential) {
                Alerts.credentialsCreateApiNull();
                return;
            }
        } catch (e) {
            alert(e.message);
            return;
        }

        const registrationResult = await completeRegistration({newCredential, csrf});
        if (!registrationResult) {
            Alerts.failedToRegister();
            return;
        }
        Alerts.registerSuccess();
        clearElementValue(elements.registerInput());
    };

    // INIT
    document.addEventListener("DOMContentLoaded", () => {
        if (!isWebauthnAvailable()) {
            Alerts.webauthnIsNotAvailable();
            return;
        }
        ensureStateCreated();
        initializeForm({state: getState(), setState, withState, formElements});
        initializeCheckboxArray({
            withState,
            setState,
            initialValues: getState()["pubKeyCredParams"],
            stateKey: "pubKeyCredParams",
            checkboxElements
        });
        elements.registerButton().addEventListener("click", onRegisterButtonHandler);
        elements.registerOptionsReset().addEventListener("click", resetState);
    });
})();
