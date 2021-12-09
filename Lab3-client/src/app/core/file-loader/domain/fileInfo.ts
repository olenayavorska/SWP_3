
export class File {
    public id: string;
    public name: string;
    public extension: string;
    public uuidName: string;
    public creationDate: Date;
    public fileURL: string;
    public viewType: string;

    constructor (fileInfo: File) {
        this.id = fileInfo.id;
        this.name = fileInfo.name;
        this.extension = fileInfo.extension;
        this.uuidName = fileInfo.uuidName;
        this.creationDate = fileInfo.creationDate;
        this.init();
    }

    init() {
        if (this.isMSView()) {
            this.viewType = "MS";
        }
        if (this.isPDFView()) {
            this.viewType = "PDF";
        }
        if (this.isImageView()) {
            this.viewType = "IMAGE";
        }
        this.buildFileURL();
    }

    isMSView = () => {
        return ['doc', 'docx', 'xls', 'xlsx', 'ppt', 'pptx'].includes(this.extension.toLowerCase(), 0);
    }

    isPDFView = () => {
        return ['pdf'].includes(this.extension.toLowerCase(), 0);
    }

    isImageView = () => {
        return ['jpg','png','jpeg'].includes(this.extension.toLowerCase(), 0);
    }

    buildFileURL = () => {
        let url = "http://localhost:3000/api/file/" + this.id;
        if (this.isMSView()) {
            this.fileURL = "http://docs.google.com/gview?url=" + url + "&embedded=true";
        }
        if (this.isPDFView()) {
            this.fileURL = "http://docs.google.com/gview?url=" + url + "&embedded=true";
        }
        if (this.isImageView()) {
            this.fileURL = url;
        }
    }

    static create(name, extension) {
        return new File(<File>{});
    }
}