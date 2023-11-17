let burgerBtn = document.getElementById("burger_btn");
burgerBtn.addEventListener("click", () => {
	let mobilePopup = document.getElementById("mobile_popup_header");
	let headerDiv = document.querySelector('.header_div');
	let burgerLines = document.querySelectorAll('.burger_line');
	let logoBlack = document.querySelector('.logo_black');
	let body = document.getElementsByTagName('Body');
	if (mobilePopup.classList.contains('mobile_pop_visible')) {
		mobilePopup.classList.remove("mobile_pop_visible");
		headerDiv.classList.remove("header_div_black");
		logoBlack.classList.remove("logo_white");
		burgerLines.forEach(function (elem) {
			elem.classList.remove("burger_line_white");
			burgerLines[0].classList.remove("burger_up_line_rotate");
			burgerLines[1].classList.remove("burger_middle_line_hidden");
			burgerLines[2].classList.remove("burger_lower_line_rotate");
		});		
		body[0].classList.remove("overflow_hid_body");
	}
	else {
		mobilePopup.classList.add("mobile_pop_visible");
		headerDiv.classList.add("header_div_black");
		logoBlack.classList.add("logo_white");
		burgerLines.forEach(function (elem) {
			elem.classList.add("burger_line_white");
			burgerLines[0].classList.add("burger_up_line_rotate");
			burgerLines[1].classList.add("burger_middle_line_hidden");
			burgerLines[2].classList.add("burger_lower_line_rotate");
		});
		body[0].classList.add("overflow_hid_body");
	}
});
(function () {
    var HOST = "https://localhost:7114/Admin/UploadImageTrix"

    addEventListener("trix-attachment-add", function (event) {
        if (event.attachment.file) {
            uploadFileAttachment(event.attachment)
        }
    })

    function uploadFileAttachment(attachment) {
        uploadFile(attachment.file, setProgress, setAttributes)
        function setProgress(progress) {
            attachment.setUploadProgress(progress)
        }

        function setAttributes(attributes) {
            attachment.setAttributes(attributes)
        }
    }

    function uploadFile(file, progressCallback, successCallback) {
        var key = createStorageKey(file)
        var formData = createFormData(key, file)
        var xhr = new XMLHttpRequest()
        xhr.open("POST", HOST, true)
        //xhr.setRequestHeader("X-File-Name", file.name);
        xhr.setRequestHeader("X-File-Size", file.size);
        xhr.setRequestHeader("X-File-Type", file.type);
        xhr.upload.addEventListener("progress", function (event) {
            var progress = event.loaded / event.total * 100
            progressCallback(progress)
        })

        xhr.addEventListener("load", function (event) {
            if (xhr.status == 204) {
                var attributes = {
                    url: HOST + key,
                    href: HOST + key + "?content-disposition=attachment"
                }
                successCallback(attributes)
            }
        })

        xhr.send(formData)
    }

    function createStorageKey(file) {
        var date = new Date()
        var day = date.toISOString().slice(0, 10)
        var name = date.getTime() + "-" + file.name
        return ["tmp", day, name].join("/")
    }

    function createFormData(key, file) {
        var data = new FormData()
        data.append("key", key)
        data.append("Content-Type", file.type)
        data.append("file", file)
        return data
    }
})();