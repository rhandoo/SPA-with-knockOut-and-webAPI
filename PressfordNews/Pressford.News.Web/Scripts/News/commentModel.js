function Comment(data) {
    var self = this;
    data = data || {};

    // Persisted properties
    self.CommentId = data.CommentId;
    self.ArticleId = data.ArticleId;
    self.Message = ko.observable(data.Message || "");
    self.CommentedBy = data.CommentedBy || "";
    self.CommentedDate = data.CommentedDate;
    self.error = ko.observable();
    //persist edits to real values on accept
    self.deleteComment = function () {
    }

    return self;
}